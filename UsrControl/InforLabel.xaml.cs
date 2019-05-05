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

namespace UsrControl
{
    /// <summary>
    /// InforLabel.xaml 的交互逻辑
    /// </summary>
    public partial class InforLabel : UserControl
    {
        public InforLabel()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, ""); SetValue(TextProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
            typeof(string), typeof(InforLabel), new PropertyMetadata("Text",
                (sender, args) => { ((InforLabel)sender).txtBoxInforLabel.Text = args.NewValue.ToString(); }
        ));

        public string Height
        {
            get { return (string)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height",
            typeof(string), typeof(InforLabel), new PropertyMetadata("Height",
                (sender, args) => { ((InforLabel)sender).gridInforLabel.Height = int.Parse(args.NewValue.ToString()); }
        ));

        public string FontSize
        {
            get { return (string)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize",
            typeof(string), typeof(InforLabel), new PropertyMetadata("FontSize",
                (sender, args) => { ((InforLabel)sender).txtBoxInforLabel.FontSize = int.Parse(args.NewValue.ToString()); }
        ));

        public string MaxWidth
        {
            get { return (string)GetValue(MaxWidthProperty); }
            set { SetValue(MaxWidthProperty, value); }
        }

        public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register("MaxWidth",
            typeof(string), typeof(InforLabel), new PropertyMetadata("MaxWidth",
                (sender, args) => { ((InforLabel)sender).txtBoxInforLabel.MaxWidth = int.Parse(args.NewValue.ToString()); }
        ));

        public string MaxHeight
        {
            get { return (string)GetValue(MaxHeightProperty); }
            set { SetValue(MaxHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxHeightProperty = DependencyProperty.Register("MaxHeight",
            typeof(string), typeof(InforLabel), new PropertyMetadata("MaxHeight",
                (sender, args) => { ((InforLabel)sender).txtBoxInforLabel.MaxHeight = int.Parse(args.NewValue.ToString()); }
        ));

        public string ReadOnly
        {
            get { return (string)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty ReadOnlyProperty = DependencyProperty.Register("ReadOnly",
            typeof(string), typeof(InforLabel), new PropertyMetadata("ReadOnly",
                (sender, args) => { ((InforLabel)sender).txtBoxInforLabel.IsReadOnly = bool.Parse(args.NewValue.ToString()); }
        ));



        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridInforLabel.Background = new SolidColorBrush(Color.FromRgb(245, 237, 229));
            txtBoxInforLabel.IsEnabled = true;
            txtBoxInforLabel.Focus();
            txtBoxInforLabel.Select(0, txtBoxInforLabel.Text.Length);
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtBoxInforLabel.IsEnabled = false;
                gridInforLabel.Background = new SolidColorBrush(Color.FromRgb(209, 232, 255));
            }
        }

        /// <summary>
        /// 刷新Text属性的值为当前文本框的值
        /// </summary>
        public void updateTxtBox()
        {
            Text= txtBoxInforLabel.Text;
        }

        private void txtBoxInforLabel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (this.Name)
            {
                case "ucAge":
                    #region 对年龄输入进行控制
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
                            updateTxtBox();
                            if (Regex.IsMatch(txtBoxInforLabel.Text, "[^0-9]|[0-9]{3,}"))
                            {
                                Text = "20";
                                RxDialog.show("年龄取值为【0-99】的数字，所输为非法值，已自动将其置为默认值", RxDialogResultButton.OK);
                            }
                            break;

                        default:
                            e.Handled = true;
                            break;
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            
        }
    }
}
