using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;
using UsrControl;

namespace Management
{
    /// <summary>
    /// Management.xaml 的交互逻辑
    /// </summary>
    public partial class Management : Page
    {
        public Management()
        {
            InitializeComponent();
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Focus();

            if ((sender as TextBox).Text == "药名" || (sender as TextBox).Text == "进价" || (sender as TextBox).Text == "售价")
            {
                (sender as TextBox).Text = "";
            }

            switch ((sender as TextBox).Name)
            {
                case "txtBox0":
                    (sender as TextBox).ToolTip = "中药名";
                    break;

                case "txtBox1":
                    (sender as TextBox).ToolTip = "中药进价(单位：元/kg)";
                    break;

                case "txtBox2":
                    (sender as TextBox).ToolTip = "中药售价(单位：元/kg)";
                    break;

                default:
                    break;
            }
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            HiddenTextBox.Focus();
            switch ((sender as TextBox).Name)
            {
                case "txtBox0":
                    if ((sender as TextBox).Text == "")
                    {
                        (sender as TextBox).Text = "药名";
                    }
                    break;

                case "txtBox1":
                    if ((sender as TextBox).Text == "")
                    {
                        (sender as TextBox).Text = "进价";
                    }
                    break;

                case "txtBox2":
                    if ((sender as TextBox).Text == "")
                    {
                        (sender as TextBox).Text = "售价";
                    }
                    break;

                default:
                    break;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "btn0")
            {
                saveMediInfo();
            }
            else
            {
                txtBox0.Text = "药名";
                txtBox1.Text = "进价";
                txtBox2.Text = "售价";
            }
        }

        /// <summary>
        /// 保存中药信息
        /// </summary>
        private void saveMediInfo()
        {
            if (txtBox0.Text == "药名" || txtBox0.Text == "" || txtBox1.Text == "进价" || txtBox1.Text == "" || txtBox2.Text == "售价" || txtBox2.Text == "")
            {
                RxDialog.show("输入的信息不完整，请完善后再执行此操作！", RxDialogResultButton.OK);
                return;
            }

            if (ChineseConvertor.Convert(txtBox0.Text.Trim()) == "")
            {
                RxDialog.show("输入的药品名不是汉字！", RxDialogResultButton.OK);
                return;
            }

            #region 追加节点
            string filePath = @"medicineprice.xml";

            if (File.Exists(filePath))
            {
                XDocument xDocument = XDocument.Load(filePath);
                var section = xDocument.Descendants("RECORD")
                    .Where(p => p.Element("name").Value == txtBox0.Text.Trim());

                if (section.Count() == 0)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(filePath);

                    XmlNode RECORD = xmlDocument.CreateNode("element", "RECORD", "");
                    XmlNode name = xmlDocument.CreateNode("element", "name", "");
                    XmlNode pinCode = xmlDocument.CreateNode("element", "pinCode", "");
                    XmlNode purchasePrice = xmlDocument.CreateNode("element", "purchasePrice", "");
                    XmlNode salePrice = xmlDocument.CreateNode("element", "salePrice", "");

                    name.InnerText = txtBox0.Text;
                    pinCode.InnerText = ChineseConvertor.Convert(txtBox0.Text);
                    purchasePrice.InnerText = txtBox1.Text;
                    salePrice.InnerText = txtBox2.Text;

                    RECORD.AppendChild(name);
                    RECORD.AppendChild(pinCode);
                    RECORD.AppendChild(purchasePrice);
                    RECORD.AppendChild(salePrice);

                    var root = xmlDocument.DocumentElement;//取到根结点
                    root.AppendChild(RECORD);
                    xmlDocument.Save(filePath);

                    RxDialog.show("入库成功", RxDialogResultButton.OK);
                }
                else
                {
                    var result =
                        RxDialog.show("库中已有此药品，是否仍要添加？", RxDialogResultButton.YesNo);

                    if (result == RxDialogResult.yes)
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(filePath);

                        XmlNodeList nodelist = xmlDocument.SelectNodes("descendant::RECORD");
                        foreach (var item in nodelist)
                        {
                            if ((item as XmlNode).ChildNodes[0].InnerText == txtBox0.Text.Trim())
                            {
                                (item as XmlNode).ChildNodes[2].InnerText = txtBox1.Text;
                                (item as XmlNode).ChildNodes[3].InnerText = txtBox2.Text;

                                xmlDocument.Save(filePath);
                                RxDialog.show("添加成功！", RxDialogResultButton.OK);
                                break;
                            }
                        }
                    }
                }

            }
            else
            {
                RxDialog.show("系统文件缺失！", RxDialogResultButton.OK);
            }

            #endregion
        }

        private void txtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Delete || e.Key == Key.Back
                    || e.Key == Key.OemPeriod || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                    || e.Key == Key.Left || e.Key == Key.Right))
                e.Handled = true;

        }
    }

    public class ChineseConvertor
    {
        private ChineseConvertor() { }
        /// <summary>
        /// 获取一串汉字的拼音声母
        /// </summary>
        /// <param name="chinese">Unicode格式的汉字字符串</param>
        /// <returns>拼音声母字符串</returns>
        /// <example>
        /// “旺旺软件工作室”转换为“wwrjgzs”
        /// </example>
        public static String Convert(String chinese)
        {
            if (Regex.IsMatch(chinese, @"[\u4e00-\u9fbb]+$"))
            {
                char[] buffer = new char[chinese.Length];
                for (int i = 0; i < chinese.Length; i++)
                {
                    buffer[i] = Convert(chinese[i]);
                }
                return new String(buffer);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取一个汉字的拼音声母
        /// </summary>
        /// <param name="chinese">Unicode格式的一个汉字</param>
        /// <returns>汉字的声母</returns>
        public static char Convert(Char chinese)
        {
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            Encoding unicode = Encoding.Unicode;
            // Convert the string into a byte[].
            byte[] unicodeBytes = unicode.GetBytes(new Char[] { chinese });
            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, gb2312, unicodeBytes);
            // 计算该汉字的GB-2312编码
            int n = (int)asciiBytes[0] << 8;
            n += (int)asciiBytes[1];
            // 根据汉字区域码获取拼音声母
            if (In(0xB0A1, 0xB0C4, n)) return 'A';
            if (In(0XB0C5, 0XB2C0, n)) return 'B';
            if (In(0xB2C1, 0xB4ED, n)) return 'C';
            if (In(0xB4EE, 0xB6E9, n)) return 'D';
            if (In(0xB6EA, 0xB7A1, n)) return 'E';
            if (In(0xB7A2, 0xB8c0, n)) return 'F';
            if (In(0xB8C1, 0xB9FD, n)) return 'G';
            if (In(0xB9FE, 0xBBF6, n)) return 'H';
            if (In(0xBBF7, 0xBFA5, n)) return 'J';
            if (In(0xBFA6, 0xC0AB, n)) return 'K';
            if (In(0xC0AC, 0xC2E7, n)) return 'L';
            if (In(0xC2E8, 0xC4C2, n)) return 'M';
            if (In(0xC4C3, 0xC5B5, n)) return 'N';
            if (In(0xC5B6, 0xC5BD, n)) return 'O';
            if (In(0xC5BE, 0xC6D9, n)) return 'P';
            if (In(0xC6DA, 0xC8BA, n)) return 'Q';
            if (In(0xC8BB, 0xC8F5, n)) return 'R';
            if (In(0xC8F6, 0xCBF0, n)) return 'S';
            if (In(0xCBFA, 0xCDD9, n)) return 'T';
            if (In(0xCDDA, 0xCEF3, n)) return 'W';
            if (In(0xCEF4, 0xD188, n)) return 'X';
            if (In(0xD1B9, 0xD4D0, n)) return 'Y';
            if (In(0xD4D1, 0xD7F9, n)) return 'Z';
            return '\0';
        }
        private static bool In(int Lp, int Hp, int Value)
        {
            return ((Value <= Hp) && (Value >= Lp));
        }
    }
}
