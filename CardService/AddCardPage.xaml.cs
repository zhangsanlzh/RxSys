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
using UsrControl;

namespace CardService
{
    /// <summary>
    /// AddCardPage.xaml 的交互逻辑
    /// </summary>
    public partial class AddCardPage : Page
    {
        public AddCardPage()
        {
            InitializeComponent();
        }

        private void popBtn_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnSave":
                    Pop.IsOpen = false;//使弹出菜单消失
                    var result = RxDialog.show("是否保存？", RxDialogResultButton.YesNo);
                    if (result == RxDialogResult.yes)
                        save();

                    break;

                case "btnReset":
                    Pop.IsOpen = false;//使弹出菜单消失
                    var result0 = RxDialog.show("是否重置所有内容？", RxDialogResultButton.YesNo);
                    if (result0 == RxDialogResult.yes)
                        reset();

                    break;

                default:
                    break;
            }
        }

        private void menuPop_Click(object sender, RoutedEventArgs e)
        {
            Pop.IsOpen = true;
        }

        private void reset()
        {
        }

        private void save()
        {
        }
    }

}
