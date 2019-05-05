using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsrControl
{
    /// <summary>
    /// TotalInfor.xaml 的交互逻辑
    /// </summary>
    public partial class TotalInfor : UserControl
    {
        public TotalInfor()
        {
            InitializeComponent();
        }

        public string Count
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, ""); SetValue(CountProperty, value); }
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count",
            typeof(string), typeof(TotalInfor), new PropertyMetadata("Count",
                (sender, args) => { ((TotalInfor)sender).count.Text = args.NewValue.ToString(); }
        ));

        public string Costs
        {
            get { return (string)GetValue(CostsProperty); }
            set { SetValue(CostsProperty, ""); SetValue(CostsProperty, value); }
        }

        public static readonly DependencyProperty CostsProperty = DependencyProperty.Register("Costs",
            typeof(string), typeof(TotalInfor), new PropertyMetadata("Costs",
                (sender, args) => { ((TotalInfor)sender).costs.Text = args.NewValue.ToString(); }
        ));


    }
}
