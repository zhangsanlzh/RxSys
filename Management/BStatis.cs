using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Management
{
    /// <summary>
    /// 营业分析
    /// </summary>
    public class BStatis
    {
        /// <summary>
        /// (日期，处方数)
        /// </summary>
        Dictionary<object,object> dicRxCount = new Dictionary<object,object>();

        /// <summary>
        /// (日期，日收入)
        /// </summary>
        Dictionary<object,object> dicIncome = new Dictionary<object, object>();

        /// <summary>
        /// 判断是否有统计数据
        /// </summary>
        public bool DataExists()
        {
            string srcDir = Directory.GetCurrentDirectory() + @"\users";

            DirectoryInfo dir = new DirectoryInfo(srcDir);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();//获取目录直接子节点

            if (fileinfo.Count() == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 对外公开的填充数据方法
        /// </summary>
        public void FillData()
        {
            string srcDir = Directory.GetCurrentDirectory() + @"\users";

            DirectoryInfo dir = new DirectoryInfo(srcDir);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();//获取目录直接子节点

            foreach (FileSystemInfo item in fileinfo)
            {
                if (item is DirectoryInfo)//判断是否文件夹
                {
                    XDocument xdoc = XDocument.Load(item.FullName + @"\" + item.Name + ".xml");
                    var section = xdoc.Descendants("RECORD");

                    double income = 0;//日收入
                    var section1 = xdoc.Descendants("RECORD")
                        .Select(p => double.Parse(p.Element("COSTS").Value));

                    //病人消费集合
                    IEnumerator<double> CostList = section1.GetEnumerator();
                    while (CostList.MoveNext())
                    {
                        income += double.Parse(CostList.Current.ToString());
                    }

                    dicRxCount.Add(item.Name, section.Count());
                    dicIncome.Add(item.Name, income);
                }
            }

            fillRxCountGraph();
            fillIncomeGraph();
        }

        /// <summary>
        /// 填充收入统计图
        /// </summary>
        private void fillIncomeGraph()
        {
            string str = "";
            IDictionaryEnumerator ide = SortDictionaryByDateTime(dicIncome).GetEnumerator();

            int index = 0;
            while (ide.MoveNext())
            {
                if (index < dicRxCount.Count - 1)
                {
                    str += "[\"" + strTimeFormat(ide.Key.ToString()) + "\"," + ide.Value + "],";
                }
                else
                {
                    str += "[\"" + strTimeFormat(ide.Key.ToString()) + "\"," + ide.Value + "]";
                }
                index++;
            }


            string filePath = System.IO.Directory.GetCurrentDirectory() + "/BStatis/Income/index.html";
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            string content = sr.ReadToEnd().Replace("{{$Income}}", str);
            sr.Close();

            File.WriteAllText(filePath, content);
        }

        /// <summary>
        /// 填充处方数统计图
        /// </summary>
        private void fillRxCountGraph()
        {
            string str = "";
            IDictionaryEnumerator ide = SortDictionaryByDateTime(dicRxCount).GetEnumerator();

            int index = 0;
            while (ide.MoveNext())
            {
                if (index < dicRxCount.Count - 1)
                {
                    str += "[\"" + strTimeFormat(ide.Key.ToString()) + "\"," + ide.Value + "],";
                }
                else
                {
                    str += "[\"" + strTimeFormat(ide.Key.ToString()) + "\"," + ide.Value + "]";
                }
                index++;
            }

            
            string filePath = System.IO.Directory.GetCurrentDirectory() + "/BStatis/index.html";
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            string content = sr.ReadToEnd().Replace("{{$RxCount}}", str);
            sr.Close();

            File.WriteAllText(filePath, content);
        }

        /// <summary>
        /// 按日期对 Dictionary排序
        /// </summary>
        /// <param name="dic"></param>
        private Dictionary<object,object> SortDictionaryByDateTime(Dictionary<object,object> dic)
        {
            //待返回的 Hash表
            Dictionary<object,object> dictionary = new Dictionary<object, object>();

            //进行排序的列表
            List<DateTime> dateList = new List<DateTime>();

            //遍历 HashTable
            foreach (var de in dic)
            {                
                dateList.Add(DateTime.Parse(strTimeFormat(de.Key.ToString())));
            }
            dateList.Sort();

            //根据 List中的键找到 HashTable中对应的值
            foreach (var date in dateList)
            {               
                var value = dic[date.ToString("yyyyMMdd")];

                dictionary.Add(date.ToString("yyyyMMdd"), value);
            }

            return dictionary;
        }

        /// <summary>
        /// 日期字符串格式化为标准形式
        /// </summary>
        /// <param name="strTime">日期字符串</param>
        /// <returns></returns>
        private string strTimeFormat(string strTime)
        {
            string year = strTime.Substring(0, 4);
            string month = strTime.Substring(4, 2);
            string day = strTime.Substring(6, 2);

            return year + "-" + month + "-" + day;
        }
    }

}
