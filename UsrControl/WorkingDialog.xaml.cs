using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UsrControl
{
    /// <summary>
    /// WorkingDialog.xaml 的交互逻辑
    /// </summary>
    public partial class WorkingDialog : Window
    {
        public WorkingDialog()
        {
            InitializeComponent();

            this.Loaded += delegate
              {
                  begin();
              };
        }

        private void begin()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private int count = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            count++;

            switch (count % 4)
            {
                case 1:
                    (stkPnl.Children[0] as Ellipse).Fill = Brushes.Red;
                    (stkPnl.Children[1] as Ellipse).Fill = Brushes.White;
                    (stkPnl.Children[2] as Ellipse).Fill = Brushes.White;
                    break;
                case 2:
                    (stkPnl.Children[0] as Ellipse).Fill = Brushes.White;
                    (stkPnl.Children[1] as Ellipse).Fill = Brushes.Green;
                    (stkPnl.Children[2] as Ellipse).Fill = Brushes.White;
                    break;
                case 3:
                    (stkPnl.Children[0] as Ellipse).Fill = Brushes.White;
                    (stkPnl.Children[1] as Ellipse).Fill = Brushes.White;
                    (stkPnl.Children[2] as Ellipse).Fill = Brushes.Yellow;
                    break;

                default:
                    break;
            }
        }

        public string txtMsg
        {
            get { return (string)GetValue(txtMsgProperty); }
            set { SetValue(txtMsgProperty, ""); SetValue(txtMsgProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty txtMsgProperty = DependencyProperty.Register("txtMsg",
            typeof(string), typeof(WorkingDialog), new PropertyMetadata("txtMsg",
                (sender, args) => { ((WorkingDialog)sender).txtMsgInfo.Text = args.NewValue.ToString(); }
        ));



    }
}
