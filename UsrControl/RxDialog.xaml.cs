using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UsrControl
{
    /// <summary>
    /// RxDialog.xaml 的交互逻辑
    /// </summary>
    public partial class RxDialog : Window
    {
        public RxDialog()
        {
            InitializeComponent();
        }

        public static RxDialogResult show(string msgInfo, RxDialogResultButton rxDialogResultButton)
        {
            RxDialog rxDialog = new RxDialog();
            rxDialog.ShowInTaskbar = false;//不在任务栏中显示
            rxDialog.Topmost = true;//在所有窗体最前方显示，不管后面的窗体是哪个

            rxDialog.txtMsgInfo.Text = msgInfo; //提示的内容

            switch (rxDialogResultButton)
            {
                case RxDialogResultButton.Yes:
                    rxDialog.no.Visibility = Visibility.Collapsed;
                    break;

                case RxDialogResultButton.OK:
                    rxDialog.no.Visibility = Visibility.Collapsed;
                    rxDialog.yes.Content = "好的";
                    break;

                default:
                    break;
            }


            #region 淡入动画
            DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(200)));
            rxDialog.BeginAnimation(UIElement.OpacityProperty, daV);

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetProperty(daV, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(daV);

            storyboard.Begin(rxDialog);//开始动画
            #endregion

            rxDialog.ShowDialog();

            if (result==1)
                return RxDialogResult.no;
            else
                return RxDialogResult.yes;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// 保存点击的结果，点是时此值为0，否时为1
        /// </summary>
        private static int result = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name=="no")
                result = 1;  
            else
                result = 0;

            Close();
            
        }
    }

    /// <summary>
    /// 设置按钮个数,YesNo是两个按钮，Yes仅有一个是按钮,OK表示按钮仅有一个且其值为好的
    /// </summary>
    public enum RxDialogResultButton
    {
        Yes=0,
        YesNo=1,
        OK =2
    }

    /// <summary>
    /// 弹框的结果
    /// </summary>
    public enum RxDialogResult
    {
        yes=0,
        no=1
    }

}
