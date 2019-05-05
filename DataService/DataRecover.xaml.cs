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
    /// DataRecover.xaml 的交互逻辑
    /// </summary>
    public partial class DataRecover : Page
    {
        public DataRecover()
        {
            InitializeComponent();
        }

        private void RecoverFromCloud_Click(object sender, RoutedEventArgs e)
        {
            sFTPHelper = new SFTPHelper("39.108.79.28", "22", "admin", "RxSys@Pwd123");

            //不存在备份
            if (!sFTPHelper.Exist(@"RxBackUp"))
            {
                RxDialog.show("云端没有可用的备份", RxDialogResultButton.OK);
                return;
            }

            workingDialog = new WorkingDialog();
            workingDialog.txtMsg = "正从云端恢复数据";
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
            RxDialog.show("已将数据从云端恢复", RxDialogResultButton.OK);
        }

        private SFTPHelper sFTPHelper = null;

        private void BackgroundWorker_DoWork_Cloud(object sender, DoWorkEventArgs e)
        {
            string srcFile = Directory.GetCurrentDirectory() + @"\medicineprice.xml";//要恢复的文件
            sFTPHelper.Get(@"RxBackUp/medicineprice.xml", srcFile);

            string desDir = @"RxBackUp/users";
            string srcDir = Directory.GetCurrentDirectory() + @"\users";//要恢复的目录
            if (!Directory.Exists(srcDir))
            {
                Directory.CreateDirectory(srcDir);
            }
            CopyDirFromCloud(desDir, srcDir);

        }

        private void CopyDirFromCloud(string desDir, string srcDir)
        {
            sFTPHelper.GetDir(desDir, srcDir);
        }

        private FolderBrowserDialog fileDialog = null;
        private WorkingDialog workingDialog = null;

        private void RecoverFromLocal_Click(object sender, RoutedEventArgs e)
        {
            fileDialog = new FolderBrowserDialog();
            fileDialog.Description = "请选择备份文件的储存位置";
            fileDialog.SelectedPath = @"d:\";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = fileDialog.SelectedPath;

                if (!Directory.Exists(fileDialog.SelectedPath+ ".RxBackUp"))
                {
                    RxDialog.show("目标位置没有可用于恢复数据的备份", RxDialogResultButton.OK);
                    return;
                }

                workingDialog = new WorkingDialog();
                workingDialog.txtMsg = "数据恢复中，请稍候";
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
            RxDialog.show("已从指定位置恢复", RxDialogResultButton.OK);
        }

        private void BackgroundWorker_DoWork_Local(object sender, DoWorkEventArgs e)
        {
            BeginRecover(fileDialog.SelectedPath);
        }

        private void BeginRecover(string selectedPath)
        {
            string desDir = selectedPath + ".RxBackUp";//目标目录
            string srcFile = Directory.GetCurrentDirectory() + @"\medicineprice.xml";//要恢复的文件
            string srcDir = Directory.GetCurrentDirectory() + @"\users";//要恢复的目录

            CopyFile(desDir, srcFile);
            CopyDirectory(desDir + @"\users", srcDir);

            DirectoryInfo dirInfo = new DirectoryInfo(desDir);
            dirInfo.Attributes = FileAttributes.Hidden;//隐藏备份的目录
        }

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

        /// <summary>
        /// 从目录复制文件
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="desDir"></param>
        private void CopyFile(string desDir, string srcFile)
        {
            File.Copy(desDir + @"\medicineprice.xml", srcFile, true);//备份文件
        }

    }

}
