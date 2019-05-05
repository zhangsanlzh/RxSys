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

namespace UsrControl
{
    /// <summary>
    /// Rx.xaml 的交互逻辑
    /// </summary>
    public partial class Rx : UserControl
    {
        public Rx()
        {
            InitializeComponent();
        }

        public string RxName
        {
            get { return (string)GetValue(RxNameProperty); }
            set { SetValue(RxNameProperty, ""); SetValue(RxNameProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxNameProperty = DependencyProperty.Register("RxName",
            typeof(string), typeof(Rx), new PropertyMetadata("RxName",
                (sender, args) => { ((Rx)sender).ucName.Text = args.NewValue.ToString(); }
        ));

        public string RxSex
        {
            get { return (string)GetValue(RxSexProperty); }
            set { SetValue(RxSexProperty, ""); SetValue(RxSexProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxSexProperty = DependencyProperty.Register("RxSex",
            typeof(string), typeof(Rx), new PropertyMetadata("RxSex",
                (sender, args) => { ((Rx)sender).ucSex.Text = args.NewValue.ToString(); }
        ));


        public string RxAge
        {
            get { return (string)GetValue(RxAgeProperty); }
            set { SetValue(RxAgeProperty, ""); SetValue(RxAgeProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxAgeProperty = DependencyProperty.Register("RxAge",
            typeof(string), typeof(Rx), new PropertyMetadata("RxAge",
                (sender, args) => { ((Rx)sender).ucAge.Text = args.NewValue.ToString(); }
        ));


        public string RxDiagnosis_desc
        {
            get { return (string)GetValue(RxDiagnosis_desc_Property); }
            set { SetValue(RxDiagnosis_desc_Property, ""); SetValue(RxDiagnosis_desc_Property, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxDiagnosis_desc_Property = DependencyProperty.Register("RxDiagnosis_desc",
            typeof(string), typeof(Rx), new PropertyMetadata("RxDiagnosis_desc",
                (sender, args) => { ((Rx)sender).ucDiagnosis_desc.Text = args.NewValue.ToString(); }
        ));


        public string RxCount
        {
            get { return (string)GetValue(RxCountProperty); }
            set { SetValue(RxCountProperty, ""); SetValue(RxCountProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxCountProperty = DependencyProperty.Register("RxCount",
            typeof(string), typeof(Rx), new PropertyMetadata("RxCount",
                (sender, args) => { ((Rx)sender).totalInfor.Count = args.NewValue.ToString(); }
        ));

        public string RxCosts
        {
            get { return (string)GetValue(RxCostsProperty); }
            set { SetValue(RxCostsProperty, ""); SetValue(RxCostsProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxCostsProperty = DependencyProperty.Register("RxCosts",
            typeof(string), typeof(Rx), new PropertyMetadata("RxCosts",
                (sender, args) => { ((Rx)sender).totalInfor.Costs = args.NewValue.ToString(); }
        ));


        public string RxDoctorName
        {
            get { return (string)GetValue(RxDoctorNameProperty); }
            set { SetValue(RxDoctorNameProperty, ""); SetValue(RxDoctorNameProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxDoctorNameProperty = DependencyProperty.Register("RxDoctorName",
            typeof(string), typeof(Rx), new PropertyMetadata("RxDoctorName",
                (sender, args) => { ((Rx)sender).txtDoctorName.Text = args.NewValue.ToString(); }
        ));

        public string RxDateTime
        {
            get { return (string)GetValue(RxDateTimeProperty); }
            set { SetValue(RxDateTimeProperty, ""); SetValue(RxDateTimeProperty, value); }//先清空再赋值，这样不会出现赋值失败的问题
        }

        public static readonly DependencyProperty RxDateTimeProperty = DependencyProperty.Register("RxDateTime",
            typeof(string), typeof(Rx), new PropertyMetadata("RxDateTime",
                (sender, args) => { ((Rx)sender).txtDateTime.Text = args.NewValue.ToString(); }
        ));

        //添加药到容器内
        public void AddHerb(Herb herb)
        {
            wrapPnl.Children.Add(herb);
        }
    }

}
