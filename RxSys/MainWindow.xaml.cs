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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RxSys
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体最小化
        /// </summary>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 拖动窗体
        /// </summary>
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //(GetTemplateChild("PnlContent") as Grid).Children.Add(new Pages.Page0());
            //(GetTemplateChild("PnlContent") as Grid).Children.Add(new Pages.Page1());
            //(GetTemplateChild("PnlContent") as Grid).Children.Add(new Page0());
            (GetTemplateChild("PnlContent") as Grid).Children.Add(new MenuPage.Page0());
        }

        private void SysBtn_Click(object sender, RoutedEventArgs e)
        {
            string btnName = (sender as Button).Name;

            switch (btnName)
            {
                case "close":
                    Close();
                    break;

                case "home":
                    MenuPage.Page0 page0 = new MenuPage.Page0();
                    page0.fadeIn(page0);

                    (GetTemplateChild("PnlContent") as Grid).Children.Clear();
                    (GetTemplateChild("PnlContent") as Grid).Children.Add(page0);
                    break;

                case "mini":
                    WindowState = WindowState.Minimized;
                    break;

                default:
                    break;
            }
        }
    }
}
