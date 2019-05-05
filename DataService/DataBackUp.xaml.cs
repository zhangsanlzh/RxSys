using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsrControl;

namespace DataService
{
    /// <summary>
    /// DataBackUp.xaml 的交互逻辑
    /// </summary>
    public partial class DataBackUp : Page
    {
        public DataBackUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 将数据备份到云端
        /// </summary>
        private void BackUpToCloud_Click(object sender, RoutedEventArgs e)
        {
            workingDialog = new WorkingDialog();
            workingDialog.txtMsg = "正在备份数据到云端";
            workingDialog.Show();

            //后台进程，负责备份
            BackgroundWorker backgroundWorker;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork_Cloud;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted_Cloud;

            //开始执行DoWork
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted_Cloud(object sender, RunWorkerCompletedEventArgs e)
        {
            workingDialog.Close();
            RxDialog.show("已备份到云", RxDialogResultButton.OK);
        }

        private SFTPHelper sFTPHelper=null;

        private void BackgroundWorker_DoWork_Cloud(object sender, DoWorkEventArgs e)
        {
            sFTPHelper = new SFTPHelper("39.108.79.28", "22", "admin", "RxSys@Pwd123");
            
            //不存在目录则创建目录
            if (!sFTPHelper.Exist(@"RxBackUp"))
                sFTPHelper.CreateDirectory(@"RxBackUp");

            string srcFile = Directory.GetCurrentDirectory() + @"\medicineprice.xml";//要备份的文件
            sFTPHelper.Put(srcFile, @"RxBackUp/medicineprice.xml");

            string desDir = @"RxBackUp/users";
            if (!sFTPHelper.Exist(desDir))
            {
                sFTPHelper.CreateDirectory(desDir);
            }

            string srcDir = Directory.GetCurrentDirectory() + @"\users";//要备份的目录
            CopyDirToCloud(srcDir, desDir);
        }

        /// <summary>
        /// 复制本地目录到云端
        /// </summary>
        /// <param name="srcDir"></param>
        private void CopyDirToCloud(string srcDir,string desDir)
        {
            DirectoryInfo dir = new DirectoryInfo(srcDir);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();//获取目录直接子节点

            foreach (FileSystemInfo item in fileinfo)
            {
                if (item is DirectoryInfo)//判断是否文件夹
                {
                    //目标目录中不存在文件夹则创建
                    if (!sFTPHelper.Exist(desDir + "/" + item.Name))
                        sFTPHelper.CreateDirectory(desDir + "/" + item.Name);

                    CopyDirToCloud(item.FullName, desDir + "/" + item.Name);//递归调用复制子文件夹
                }
                else//不是文件夹即复制文件
                    sFTPHelper.Put(item.FullName, desDir + "/" + item.Name);
            }

        }


        private FolderBrowserDialog fileDialog = null;
        private WorkingDialog workingDialog = null;

        /// <summary>
        /// 将数据备份到本地
        /// </summary>
        private void BackUpToLocal_Click(object sender, RoutedEventArgs e)
        {
            fileDialog = new FolderBrowserDialog();
            fileDialog.Description = "请选择备份文件的储存位置";
            fileDialog.SelectedPath = @"d:\";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = fileDialog.SelectedPath;

                workingDialog = new WorkingDialog();
                workingDialog.txtMsg = "备份中，请稍候";
                workingDialog.Show();

                //后台进程，负责备份
                BackgroundWorker backgroundWorker;
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += BackgroundWorker_DoWork_Local;
                backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

                //开始执行DoWork
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            workingDialog.Close();
            RxDialog.show("文件已备份到指定目录", RxDialogResultButton.OK);
        }

        private void BackgroundWorker_DoWork_Local(object sender, DoWorkEventArgs e)
        {
            BeginBackUp(fileDialog.SelectedPath);
        }


        /// <summary>
        /// 开始备份数据
        /// </summary>
        private void BeginBackUp(string path)
        {
            string desDir = path + ".RxBackUp";//目标目录
            string srcFile = Directory.GetCurrentDirectory() + @"\medicineprice.xml";//要备份的文件
            string srcDir = Directory.GetCurrentDirectory() + @"\users";//要备份的目录

            CopyFile(srcFile,desDir);
            CopyDirectory(srcDir, desDir + @"\users");

            DirectoryInfo dirInfo = new DirectoryInfo(desDir);
            dirInfo.Attributes = FileAttributes.Hidden;//隐藏备份的目录

        }

        /// <summary>
        /// 复制文件到指定目录
        /// </summary>
        /// <param name="srcFile">文件源</param>
        /// <param name="desDir">目标目录</param>
        private void CopyFile(string srcFile,string desDir)
        {
            if (Directory.Exists(desDir))
            {
                File.Copy(srcFile, desDir + @"\medicineprice.xml", true);//备份文件
            }
            else
            {
                Directory.CreateDirectory(desDir);

                File.Copy(srcFile, desDir + @"\medicineprice.xml", true);//备份文件
            }
        }

        /// <summary>
        /// 复制目录到指定目录
        /// </summary>
        /// <param name="srcDir">源目录</param>
        /// <param name="desDir">目标目录</param>
        private void CopyDirectory(string srcDir, string desDir)
        {
            //不存在目录则创建目录
            if (!Directory.Exists(desDir))
                Directory.CreateDirectory(desDir);

            DirectoryInfo dir = new DirectoryInfo(srcDir);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();//获取目录直接子节点

            foreach (FileSystemInfo item in fileinfo)
            {
                if (item is DirectoryInfo)//判断是否文件夹
                {
                    //目标目录中不存在文件夹则创建
                    if (!Directory.Exists(desDir + "\\" + item.Name))
                        Directory.CreateDirectory(desDir + "\\" + item.Name);

                    CopyDirectory(item.FullName, desDir + "\\" + item.Name);//递归调用复制子文件夹
                }
                else//不是文件夹即复制文件
                    File.Copy(item.FullName, desDir + "\\" + item.Name, true);
            }
        }

    }
}
