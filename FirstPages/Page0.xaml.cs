using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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


namespace FirstPages
{
    /// <summary>
    /// Page0.xaml 的交互逻辑
    /// </summary>
    public partial class Page0 : Page
    {
        private double Costs = 0;//总花费

        public Page0()
        {
            InitializeComponent();

            txtDateTime.Text = DateTime.Today.ToString("yyyy-M-d");//当前日期

            xDocument = XDocument.Load(filePath);
        }

        private string filePath = @"medicineprice.xml";
        private XDocument xDocument = null;

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Focus();

            if ((sender as TextBox).Text == "输入药品拼音简称搜索，如当归，dg")
            {
                (sender as TextBox).Text = "";
                (sender as TextBox).ToolTip = "输入药品拼音简称搜索，如当归，dg（不分大小写）";
            }
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            HiddenTextBox.Focus();
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "输入药品拼音简称搜索，如当归，dg";
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text == "" || (sender as TextBox).Text == "输入药品拼音简称搜索，如当归，dg")
            {
                return;
            }

            var section = xDocument.Descendants("RECORD")
                .Where(p => p.Element("pinCode").Value.Contains((sender as TextBox).Text.ToUpper()))
                .Select(p => p.Element("name").Value);

            listBox.Items.Clear();

            if (section.Count() == 0)
            {
                listBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                listBox.Visibility = Visibility.Visible;
            }

            foreach (var item in section)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = item;
                listBoxItem.Style = FindResource("ListItemStyle") as Style;
                listBoxItem.MouseDoubleClick += listBoxItem_MouseDoubleClick;
                listBoxItem.KeyDown += ListBoxItem_KeyDown;

                listBox.Items.Add(listBoxItem);
            }
        }

        private void ListBoxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                AddHerb(sender);
            }
        }

        private void listBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddHerb(sender);
        }

        /// <summary>
        /// 在处方容器中添加项
        /// </summary>
        private void AddHerb(object sender)
        {
            Herb herb = new Herb();
            herb.HerbName = (sender as ListBoxItem).Content.ToString();
            herb.HerbGram = "10";
            (FindName("wrapPnl") as WrapPanel).Children.Add(herb);

            var section = xDocument.Descendants("RECORD")
                .Where(p => p.Element("name").Value == (sender as ListBoxItem).Content.ToString())
                .Select(p => p.Element("salePrice").Value);

            //药品数量
            totalInfor.Count = wrapPnl.Children.Count.ToString();

            Costs = double.Parse(totalInfor.Costs);
            Costs += double.Parse(section.First()) * 10;//总花费

            totalInfor.Costs = Costs.ToString();

            #region 恢复状态,以便添加新药
            txtBox.Focus();//文本框重获焦点
            listBox.Items.Clear();
            listBox.Visibility = Visibility.Collapsed;
            txtBox.Clear();
            #endregion
        }

        private void menuPop_Click(object sender, RoutedEventArgs e)
        {
            Pop.IsOpen = true;
        }

        private void popBtn_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnSave":
                    Pop.IsOpen = false;//使弹出菜单消失
                    var result=RxDialog.show("是否保存？",RxDialogResultButton.YesNo);
                    if (result==RxDialogResult.yes)
                        save();

                    break;

                case "btnReset":
                    Pop.IsOpen = false;//使弹出菜单消失
                    var result0 = RxDialog.show("是否重置所有内容？",RxDialogResultButton.YesNo);
                    if (result0 == RxDialogResult.yes)
                        reset();

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 重置处方内容
        /// </summary>
        private void reset()
        {
            ucName.Text = "张三";
            cmbSex.SelectedIndex = 0;
            ucAge.Text = "20";

            ucDiagnosis_desc.Text = "脾胃失调";

            wrapPnl.Children.Clear();
            totalInfor.Count = "0";
            totalInfor.Costs = "0";

            RxDialog.show("重置成功！", RxDialogResultButton.OK);

        }

        /// <summary>
        /// 保存处方内容
        /// </summary>
        private void save()
        {
            string dateTime= DateTime.Today.ToString("yyyyMMdd");//当前日期
            string dirPath = "users/" + dateTime;//目录路径
            string filePath = dirPath + "/" + dateTime + ".xml";//文件路径

            if (Directory.Exists(dirPath))
            {
                if (File.Exists(filePath))//每天非首次保存时执行此段代码
                {
                    //追加节点，而不是重建文档
                    #region 追加节点
                    if (File.Exists(filePath))
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath);

                        XmlNode nRECORD = xmlDocument.CreateNode("element", "RECORD", "");
                        XmlNode nName = xmlDocument.CreateNode("element", "NAME", "");//姓名
                        XmlNode nSex = xmlDocument.CreateNode("element", "SEX", "");//性别
                        XmlNode nAge = xmlDocument.CreateNode("element", "AGE", "");//年龄
                        XmlNode nDiagnosis_desc = xmlDocument.CreateNode("element", "DIAGNOSIS_DESC", "");//诊断名称
                        XmlNode nUsage = xmlDocument.CreateNode("element", "USAGE", "");//用药
                        XmlNode nCount = xmlDocument.CreateNode("element", "COUNT", "");//药数
                        XmlNode nCosts = xmlDocument.CreateNode("element", "COSTS", "");//总费用
                        XmlNode nDoctorName = xmlDocument.CreateNode("element", "DOCTOR_NAME", "");//医师姓名
                        XmlNode nDateTime = xmlDocument.CreateNode("element", "DATETIME", "");//开方日期
                        XmlNode nPreciseTime = xmlDocument.CreateNode("element", "PRECISE_TIME", "");//精确时间

                        nName.InnerText = ucName.Text.Trim();
                        nSex.InnerText = cmbSex.Text.Trim();
                        nAge.InnerText = ucAge.Text.Trim();
                        nDiagnosis_desc.InnerText = ucDiagnosis_desc.Text.Trim();

                        //处方药项
                        if (wrapPnl.Children.Count > 0)
                        {
                            for (int i = 0; i < wrapPnl.Children.Count; i++)
                            {
                                XmlNode nHerbName = xmlDocument.CreateNode("element", "HERBNAME", "");//药名
                                XmlNode nHerbGram = xmlDocument.CreateNode("element", "HERBGRAM", "");//药量
                                XmlNode nItem = xmlDocument.CreateNode("element", "ITEM", "");//项

                                nHerbName.InnerText = (wrapPnl.Children[i] as Herb).HerbName;
                                nHerbGram.InnerText = (wrapPnl.Children[i] as Herb).HerbGram.Trim('g').Trim();

                                nItem.AppendChild(nHerbName);
                                nItem.AppendChild(nHerbGram);
                                nUsage.AppendChild(nItem);
                            }
                        }
                        nCount.InnerText = totalInfor.Count;
                        nCosts.InnerText = totalInfor.Costs;
                        nDoctorName.InnerText = txtDoctorName.Text.Trim();
                        nDateTime.InnerText = txtDateTime.Text.Trim();
                        nPreciseTime.InnerText = DateTime.Now.ToLocalTime().ToString("yyyy-M-d HH:mm");

                        nRECORD.AppendChild(nName);
                        nRECORD.AppendChild(nSex);
                        nRECORD.AppendChild(nAge);
                        nRECORD.AppendChild(nDiagnosis_desc);
                        nRECORD.AppendChild(nUsage);                    
                        nRECORD.AppendChild(nCount);
                        nRECORD.AppendChild(nCosts);
                        nRECORD.AppendChild(nDoctorName);
                        nRECORD.AppendChild(nDateTime);
                        nRECORD.AppendChild(nPreciseTime);

                        var root = xmlDocument.DocumentElement;//取到根结点
                        root.AppendChild(nRECORD);
                        xmlDocument.Save(filePath);

                        RxDialog.show("保存成功！", RxDialogResultButton.OK);
                    }

                    #endregion
                }
                else//此段代码在用户删掉了本天记录文件时执行
                {
                    //创建新的文件，之前本天的记录没有了
                    //可以考虑从备份文件中恢复数据
                    using (File.Create(filePath)) { }

                    fillXMLDoc(filePath);
                }
            }
            else//每天首次保存时执行此段代码
            {
                Directory.CreateDirectory(dirPath);
                using (File.Create(filePath)) { }

                fillXMLDoc(filePath);
            }
            
        }

        /// <summary>
        /// 填充一个空白的XML文档
        /// </summary>
        private void fillXMLDoc(string filePath)
        {
            #region 填充一个空白的XML文档
            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "");//xml文档的声明部分
                xmlDocument.AppendChild(declaration);

                XmlElement RECORDS = xmlDocument.CreateElement("", "RECORDS", "");

                xmlDocument.AppendChild(RECORDS);

                XmlNode nRECORD = xmlDocument.CreateNode("element", "RECORD", "");
                XmlNode nName = xmlDocument.CreateNode("element", "NAME", "");//姓名
                XmlNode nSex = xmlDocument.CreateNode("element", "SEX", "");//性别
                XmlNode nAge = xmlDocument.CreateNode("element", "AGE", "");//年龄
                XmlNode nDiagnosis_desc = xmlDocument.CreateNode("element", "DIAGNOSIS_DESC", "");//诊断名称
                XmlNode nUsage = xmlDocument.CreateNode("element", "USAGE", "");//用药
                XmlNode nCount = xmlDocument.CreateNode("element", "COUNT", "");//药数
                XmlNode nCosts = xmlDocument.CreateNode("element", "COSTS", "");//总费用
                XmlNode nDoctorName = xmlDocument.CreateNode("element", "DOCTOR_NAME", "");//医师姓名
                XmlNode nDateTime = xmlDocument.CreateNode("element", "DATETIME", "");//开方日期
                XmlNode nPreciseTime = xmlDocument.CreateNode("element", "PRECISE_TIME", "");//精确时间

                nName.InnerText = ucName.Text.Trim();
                nSex.InnerText = cmbSex.Text.Trim();
                nAge.InnerText = ucAge.Text.Trim();
                nDiagnosis_desc.InnerText = ucDiagnosis_desc.Text.Trim();

                //处方药项
                if (wrapPnl.Children.Count > 0)
                {
                    for (int i = 0; i < wrapPnl.Children.Count; i++)
                    {
                        XmlNode nHerbName = xmlDocument.CreateNode("element", "HERBNAME", "");//药名
                        XmlNode nHerbGram = xmlDocument.CreateNode("element", "HERBGRAM", "");//药量
                        XmlNode nItem = xmlDocument.CreateNode("element", "ITEM", "");//项

                        nHerbName.InnerText = (wrapPnl.Children[i] as Herb).HerbName;
                        nHerbGram.InnerText = (wrapPnl.Children[i] as Herb).HerbGram;

                        nItem.AppendChild(nHerbName);
                        nItem.AppendChild(nHerbGram);
                        nUsage.AppendChild(nItem);
                    }

                }

                nCount.InnerText = totalInfor.Count;
                nCosts.InnerText = totalInfor.Costs;
                nDoctorName.InnerText = txtDoctorName.Text.Trim();
                nDateTime.InnerText = txtDateTime.Text.Trim();
                nPreciseTime.InnerText = DateTime.Now.ToLocalTime().ToString("yyyy-M-d HH:mm");

                nRECORD.AppendChild(nName);
                nRECORD.AppendChild(nSex);
                nRECORD.AppendChild(nAge);
                nRECORD.AppendChild(nDiagnosis_desc);
                nRECORD.AppendChild(nUsage);
                nRECORD.AppendChild(nCount);
                nRECORD.AppendChild(nCosts);
                nRECORD.AppendChild(nDoctorName);
                nRECORD.AppendChild(nDateTime);
                nRECORD.AppendChild(nPreciseTime);

                var root = xmlDocument.DocumentElement;//取到根结点
                root.AppendChild(nRECORD);
                xmlDocument.Save(filePath);

                //MessageBox.Show("保存成功！");
                RxDialog.show("保存成功！", RxDialogResultButton.OK);
            }

            #endregion
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                listBox.Focus();
            }
        }

        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            HiddenTextBox.Focus();
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "输入药品拼音简称搜索，如当归，dg";
            }
        }
    }
}
