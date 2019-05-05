using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace UsrControl
{
    /// <summary>
    /// Herb.xaml 的交互逻辑
    /// </summary>
    public partial class Herb : UserControl
    {
        public Herb()
        {
            InitializeComponent();
        }

        public string HerbName
        {
            get { return (string)GetValue(HerbNameProperty); }
            set { SetValue(HerbNameProperty, value); }
        }

        public static readonly DependencyProperty HerbNameProperty = DependencyProperty.Register("HerbName",
            typeof(string), typeof(Herb), new PropertyMetadata("HerbName",
                (sender, args) => { ((Herb)sender).txtBlockHerbName.Text = args.NewValue.ToString(); }
        ));

        public string HerbGram
        {
            get { return (string)GetValue(HerbGramProperty); }
            set { SetValue(HerbGramProperty, value); }
        }

        public static readonly DependencyProperty HerbGramProperty = DependencyProperty.Register("HerbGram",
            typeof(string), typeof(Herb), new PropertyMetadata("HerbGram",
                (sender, args) => { ((Herb)sender).txtBoxHerbGram.Text = args.NewValue.ToString() + " g"; }
        ));

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty ReadOnlyProperty = DependencyProperty.Register("ReadOnly",
            typeof(bool), typeof(Herb), new PropertyMetadata(false,
                (sender, args) => {((Herb)sender).txtBoxHerbGram.IsReadOnly = (bool)args.NewValue;}
        ));


        bool isMouseDown = false;
        private void herb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton== MouseButtonState.Pressed)
            {
                gridPnl.Background = new SolidColorBrush(Color.FromRgb(245, 237, 229));
                txtBoxHerbGram.IsEnabled = true;

                //使文本框获得焦点
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render,
                    new Action(() => txtBoxHerbGram.Focus()));

                txtBoxHerbGram.Select(0, txtBoxHerbGram.Text.Length - 2);
                isMouseDown = true;
            }

            if (e.RightButton== MouseButtonState.Pressed)
            {
                if (!ReadOnly)
                    herbPop.IsOpen = true;
            }
        }

        private void herb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtBoxHerbGram.IsEnabled = false;
                gridPnl.Background = new SolidColorBrush(Color.FromRgb(209, 232, 255));
                isMouseDown = false;
            }
        }

        private void herb_MouseEnter(object sender, MouseEventArgs e)
        {
            gridPnl.Background = new SolidColorBrush(Color.FromRgb(245, 237, 229));
            Cursor = Cursors.Hand;
        }

        private void herb_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
            {
                gridPnl.Background = new SolidColorBrush(Color.FromRgb(209, 232, 255));
            }
        }

        private void popBtn_Click(object sender, RoutedEventArgs e)
        {

            List<Grid> list = FindVisualParent<Grid>(gridPnl);
            foreach (var item in list)
            {
                if (item.Name=="PnlContent")
                {
                    UsrControl.TotalInfor element = FindChild<UsrControl.TotalInfor>(item, "totalInfor");

                    int count = int.Parse(element.Count);
                    element.Count = (--count).ToString();

                    string filePath = @"medicineprice.xml";
                    XDocument xDocument = XDocument.Load(filePath);

                    var section = xDocument.Descendants("RECORD")
                        .Where(p => p.Element("name").Value == herb.HerbName)
                        .Select(p => p.Element("salePrice").Value);

                    double costs = double.Parse(element.Costs);
                    costs -= double.Parse(section.First()) * int.Parse(HerbGram.Trim('g').Trim());//总花费
                    element.Costs = costs.ToString();

                    (herb.VisualParent as WrapPanel).Children.Remove(herb);

                }
            }
        }

        /// <summary>
        /// 利用VisualTreeHelper寻找指定依赖对象的父级对象
        /// </summary>
        private static List<T> FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            try
            {
                List<T> TList = new List<T> { };
                DependencyObject parent = VisualTreeHelper.GetParent(obj);
                if (parent != null && parent is T)
                {
                    TList.Add((T)parent);
                    List<T> parentOfParent = FindVisualParent<T>(parent);
                    if (parentOfParent != null)
                    {
                        TList.AddRange(parentOfParent);
                    }
                }
                else if (parent != null)
                {
                    List<T> parentOfParent = FindVisualParent<T>(parent);
                    if (parentOfParent != null)
                    {
                        TList.AddRange(parentOfParent);
                    }
                }
                return TList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 在Visual里找到想要的元素
        /// childName可为空，不为空就按名字找
        /// </summary>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                T childType = child as T;
                if (childType == null)
                {
                    // 住下查要找的元素
                    foundChild = FindChild<T>(child, childName);

                    // 如果找不到就反回
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // 看名字是不是一样
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        //如果名字一样返回
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // 找到相应的元素了就返回 
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        private void txtBoxHerbGram_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            #region 对药量输入进行控制
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Back:
                case Key.Delete:
                    break;

                case Key.Enter:
                    int oldGram = int.Parse(HerbGram.Trim('g').Trim());//原来的量
                    HerbGram = txtBoxHerbGram.Text;
                    if (Regex.IsMatch(HerbGram, "[^0-9] g"))
                    {
                        HerbGram = "10";
                        RxDialog.show("所输为非法值，已自动将其置为默认值", RxDialogResultButton.OK);
                    }
                    else
                    {
                        txtBoxHerbGram.Text = HerbGram;//显示成现在的量，这么做的原因是显示成正确的格式

                        int newGram = int.Parse(HerbGram.Trim('g').Trim());//现在的量

                        List<Grid> list = FindVisualParent<Grid>(gridPnl);
                        foreach (var item in list)
                        {
                            if (item.Name == "PnlContent")
                            {

                                UsrControl.TotalInfor element = FindChild<UsrControl.TotalInfor>(item, "totalInfor");

                                string filePath = @"medicineprice.xml";
                                XDocument xDocument = XDocument.Load(filePath);

                                var section = xDocument.Descendants("RECORD")
                                    .Where(p => p.Element("name").Value == herb.HerbName)
                                    .Select(p => p.Element("salePrice").Value);

                                double costs = double.Parse(element.Costs);
                                costs += double.Parse(section.First()) * (newGram-oldGram);//总花费
                                element.Costs = costs.ToString();
                            }
                        }
                    }
                    break;

                default:
                    e.Handled = true;
                    break;
            }
            #endregion
        }
    }
}
