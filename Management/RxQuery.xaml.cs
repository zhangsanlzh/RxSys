using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using UsrControl;

namespace Management
{
    /// <summary>
    /// RxQuery.xaml 的交互逻辑
    /// </summary>
    public partial class RxQuery : Page
    {

        public RxQuery()
        {
            InitializeComponent();
        }

        private XmlDocument xmlDocument = null;

        /// <summary>
        /// 处方个数
        /// </summary>
        private int RxCount = 0;

        /// <summary>
        /// 根据日期类型填充处方
        /// </summary>
        /// <param name=""></param>
        private void fillRx(RxDateType dateType)
        {
            switch (dateType)
            {
                case RxDateType.Today:
                    string dateTimeToday = DateTime.Today.ToString("yyyyMMdd");//当前日期

                    string filePath0 = @"users/" + dateTimeToday + "/" + dateTimeToday + ".xml";

                    if (File.Exists(filePath0))
                    {
                        xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath0);

                        RxCount = xmlDocument.DocumentElement.ChildNodes.Count;//处方数

                        tBtn0.Content = "今天 (" + RxCount + "个)";

                        for (int i = 0; i < RxCount; i++)
                        {
                            fillRx(i, dateType);
                        }
                    }
                    else
                        tBtn0.Content = "今天 (0个)";

                    break;

                case RxDateType.YesterDay:
                    string dateTimeYesterDay = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");//当前日期

                    string filePath1 = @"users/" + dateTimeYesterDay + "/" + dateTimeYesterDay + ".xml";

                    if (File.Exists(filePath1))
                    {
                        xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath1);

                        RxCount = xmlDocument.DocumentElement.ChildNodes.Count;//处方数
                        tBtn1.Content = "昨天 (" + RxCount + "个)";

                        for (int i = 0; i < RxCount; i++)
                        {
                            fillRx(i, dateType);
                        }
                    }
                    else
                        tBtn1.Content = "昨天 (0个)";

                    break;
                case RxDateType.BeforeYesterDay:
                    string dateTimeBeforeYesterDay = DateTime.Today.AddDays(-2).ToString("yyyyMMdd");//当前日期

                    string filePath2 = @"users/" + dateTimeBeforeYesterDay + "/" + dateTimeBeforeYesterDay + ".xml";

                    if (File.Exists(filePath2))
                    {
                        xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath2);

                        RxCount = xmlDocument.DocumentElement.ChildNodes.Count;//处方数
                        tBtn2.Content = "前天 (" + RxCount + "个)";

                        for (int i = 0; i < RxCount; i++)
                        {
                            fillRx(i, dateType);
                        }
                    }
                    else
                        tBtn2.Content = "前天 (0个)";

                    break;

                case RxDateType.LongAgo:
                    string dateTimeLongAgo = DateTime.Parse(datePicker.SelectedDate.ToString()).ToString("yyyyMMdd");//当前日期

                    string filePath3 = @"users/" + dateTimeLongAgo + "/" + dateTimeLongAgo + ".xml";

                    if (File.Exists(filePath3))
                    {
                        xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath3);

                        RxCount = xmlDocument.DocumentElement.ChildNodes.Count;//处方数
                        tBtn3.Content = "更早之前 (" + DateTime.Parse(datePicker.SelectedDate.ToString()).ToString("yyyy-MM-dd") + " "+ RxCount + "个)";

                        for (int i = 0; i < RxCount; i++)
                        {
                            fillRx(i, dateType);
                        }
                    }
                    else
                        tBtn3.Content = "更早之前 (" + DateTime.Parse(datePicker.SelectedDate.ToString()).ToString("yyyy-MM-dd") + " 0个)";                    

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 根据日期类型填充记录中的第i个处方
        /// </summary>
        /// 
        private void fillRx(int i, RxDateType dateType)
        {
            try
            {
                string name = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText;//姓名
                string sex = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText;//性别
                string age = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText;//年龄
                string diagnosis_desc = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[3].InnerText;//诊断描述
                string count = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[5].InnerText;//药数
                string costs = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[6].InnerText;//花费
                string doctor_name = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[7].InnerText;//医师姓名
                string datetime = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[8].InnerText;//开方日期

                Rx rx = new Rx();

                rx.RxName = name;
                rx.RxSex = sex;
                rx.RxAge = age;
                rx.RxDiagnosis_desc = diagnosis_desc;
                rx.RxCount = count;
                rx.RxCosts = costs;
                rx.RxDoctorName = doctor_name;
                rx.RxDateTime = datetime;

                int xCount = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[4].ChildNodes.Count;//药数

                //添加药
                for (int j = 0; j < xCount; j++)
                {
                    string RxHerbName = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[4].ChildNodes.Item(j).ChildNodes[0].InnerText;
                    string RxHerbGram = xmlDocument.DocumentElement.ChildNodes[i].ChildNodes[4].ChildNodes.Item(j).ChildNodes[1].InnerText;

                    Herb herb = new Herb();
                    herb.HerbName = RxHerbName;
                    herb.HerbGram = RxHerbGram;
                    herb.ReadOnly = true;

                    rx.AddHerb(herb);
                }

                switch (dateType)
                {
                    case RxDateType.Today:
                        rx.Tag = i;     //设置此元素的编号                    
                        AddContextMenu(rx);
                        wrapPnl0.Children.Add(rx);
                        wrapPnl0.Children[i].MouseDown += RxQuery_MouseDown;
                        wrapPnl0.Tag = "wrapPnl0";
                        break;
                    case RxDateType.YesterDay:
                        rx.Tag = i;     //设置此元素的编号
                        AddContextMenu(rx);
                        wrapPnl1.Children.Add(rx);
                        wrapPnl1.Children[i].MouseDown += RxQuery_MouseDown;
                        wrapPnl1.Tag = "wrapPnl1";
                        break;
                    case RxDateType.BeforeYesterDay:
                        rx.Tag = i;     //设置此元素的编号
                        AddContextMenu(rx);
                        wrapPnl2.Children.Add(rx);
                        wrapPnl2.Children[i].MouseDown += RxQuery_MouseDown;
                        wrapPnl2.Tag = "wrapPnl2";
                        break;
                    case RxDateType.LongAgo:
                        rx.Tag = i;     //设置此元素的编号
                        AddContextMenu(rx);
                        wrapPnl3.Children.Add(rx);
                        wrapPnl3.Children[i].MouseDown += RxQuery_MouseDown;        //为每一项添加鼠标点击事件 
                        wrapPnl3.Tag = "wrapPnl3";
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
                RxDialog.show("记录文件被损坏", RxDialogResultButton.OK);
            }
        }

        /// <summary>
        /// 为 Rx控件添加右键菜单
        /// </summary>
        /// <param name="rx"></param>
        private void AddContextMenu(Rx rx)
        {
            rx.ContextMenu = (ContextMenu)FindResource("RxMenu");
        }

        /// <summary>
        /// 删除处方
        /// </summary>
        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            switch (WrapPnlTag)
            {
                case "wrapPnl0":
                    wrapPnl0.Children.RemoveAt(RxTag);

                    string dateTimeToday = DateTime.Today.ToString("yyyyMMdd");//当前日期
                    DeleteRecord(dateTimeToday, RxTag);

                    tBtn0.Content = "今天 (" + --RxCount + "个)";
                    break;

                case "wrapPnl1":
                    wrapPnl1.Children.RemoveAt(RxTag);

                    string dateTimeYesterDay = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");//当前日期
                    DeleteRecord(dateTimeYesterDay, RxTag);

                    tBtn1.Content = "昨天 (" + --RxCount + "个)";
                    break;

                case "wrapPnl2":
                    wrapPnl2.Children.RemoveAt(RxTag);

                    string dateTimeBeforeYesterDay = DateTime.Today.AddDays(-2).ToString("yyyyMMdd");//当前日期
                    DeleteRecord(dateTimeBeforeYesterDay, RxTag);

                    tBtn2.Content = "前天 (" + --RxCount + "个)";
                    break;

                case "wrapPnl3":
                    wrapPnl3.Children.RemoveAt(RxTag);

                    string dateTimeLongAgo = DateTime.Parse(datePicker.SelectedDate.ToString()).ToString("yyyyMMdd");//当前日期
                    DeleteRecord(dateTimeLongAgo, RxTag);

                    tBtn3.Content = "更早之前 (" + --RxCount + "个)";
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 根据日期和处方编号删除处方记录
        /// </summary>
        /// <param name="strDateTime">日期</param>
        /// <param name="RxTag">处方编号</param>
        private void DeleteRecord(string strDateTime,int RxTag)
        {
            string filePath = @"users/" + strDateTime + "/" + strDateTime + ".xml";

            xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNode xmlNode=xmlDocument.SelectSingleNode("RECORDS").ChildNodes[RxTag];
            xmlDocument.DocumentElement.RemoveChild(xmlNode);

            xmlDocument.Save(filePath);
        }

        /// <summary>
        /// 点击的处方编号
        /// </summary>
        private int RxTag = 0;

        /// <summary>
        /// 点击的 WrapPnl值
        /// </summary>
        private string WrapPnlTag = "";

        /// <summary>
        /// 获取编号的值
        /// </summary>
        private void RxQuery_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                RxTag = (int)(sender as Rx).Tag;
                WrapPnlTag = ((sender as Rx).Parent as WrapPanel).Tag.ToString();
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((sender as ToggleButton).Name + "\n" + (sender as ToggleButton).IsChecked.ToString());
            switch ((sender as ToggleButton).Name)
            {                
                //今天
                case "tBtn0":
                    if ((bool)(sender as ToggleButton).IsChecked)
                    {
                        grid0.Visibility = Visibility.Visible;

                        if (wrapPnl0.Children.Count==0)//填充当日药方
                        {
                            fillRx(RxDateType.Today);
                        }
                    }
                    else
                    {
                        grid0.Visibility = Visibility.Collapsed;
                        grid1.IsEnabled = false;
                        grid2.IsEnabled = false;
                    }
                    break;

                //昨天
                case "tBtn1":
                    if ((bool)(sender as ToggleButton).IsChecked)
                    {
                        grid1.Visibility = Visibility.Visible;

                        if (wrapPnl1.Children.Count == 0)//填充当日药方
                        {
                            fillRx(RxDateType.YesterDay);
                        }
                    }
                    else
                    {
                        grid1.Visibility = Visibility.Collapsed;
                        grid0.IsEnabled = false;
                        grid2.IsEnabled = false;
                    }
                    break;

                //前天
                case "tBtn2":
                    if ((bool)(sender as ToggleButton).IsChecked)
                    {
                        grid2.Visibility = Visibility.Visible;

                        if (wrapPnl2.Children.Count == 0)//填充当日药方
                        {
                            fillRx(RxDateType.BeforeYesterDay);
                        }
                    }
                    else
                    {
                        grid2.Visibility = Visibility.Collapsed;
                        grid0.IsEnabled = false;
                        grid1.IsEnabled = false;
                    }
                    break;

                //更早之前
                case "tBtn3":
                    if ((bool)(sender as ToggleButton).IsChecked)
                    {
                        grid3.Visibility = Visibility.Visible;
                        searchBtn.Visibility = Visibility.Visible;
                        datePicker.Visibility=Visibility.Visible;
                        datePicker.SelectedDate = DateTime.Today.AddDays(-3);

                        datePicker.DisplayDateEnd = DateTime.Today.AddDays(-3);//结束时间
                    }
                    else
                    {
                        grid3.Visibility = Visibility.Collapsed;
                        grid0.IsEnabled = false;
                        grid1.IsEnabled = false;
                        grid2.IsEnabled = false;

                    }
                    break;

                default:
                    break;
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            wrapPnl3.Children.Clear();

            fillRx(RxDateType.LongAgo);
        }
    }

    public enum RxDateType
    {
        /// <summary>
        /// 今天
        /// </summary>
        Today=0,
        /// <summary>
        /// 昨天
        /// </summary>
        YesterDay=1,
        /// <summary>
        /// 前天
        /// </summary>
        BeforeYesterDay=2,
        /// <summary>
        /// 更早之前
        /// </summary>
        LongAgo=3
    }

    
}
