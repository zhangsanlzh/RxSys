using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardService;
using DataService;
using UsrControl;

namespace MenuPage
{
    /// <summary>
    /// Page0.xaml 的交互逻辑
    /// </summary>
    public partial class Page0 : Page
    {
        public Page0()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 被点击的按钮名称
        /// </summary>
        private string btnClickedName = "";

        /// <summary>
        /// 设置按钮点击效果
        /// </summary>
        private void FucBtn_Click(object sender, RoutedEventArgs e)
        {
            string btnName = (sender as Button).Name;

            //设置按钮点击效果
            switch (btnName)
            {
                //开方
                case "btn0":
                    btnClickedName = (sender as Button).Name;

                    leftTrans(btn0);
                    fadeOut();
                    break;

                //处方管理
                case "btn1":
                    btnClickedName = (sender as Button).Name;

                    topTrans(btn1);
                    fadeOut();
                    break;
                
                //中药入库
                case "btn2":
                    btnClickedName = (sender as Button).Name;

                    topTrans(btn2);
                    fadeOut();
                    break;

                //营业统计
                case "btn3":
                    btnClickedName = (sender as Button).Name;

                    Management.BStatis bStatis = new Management.BStatis();
                    if (bStatis.DataExists())
                    {
                        bStatis.FillData();
                        Process.Start(System.IO.Directory.GetCurrentDirectory() + "/BStatis/index.html");
                    }
                    else
                        RxDialog.show("没有可分析的数据", RxDialogResultButton.OK);
                    break;

                ////办卡
                //case "btn4":
                //    btnClickedName = (sender as Button).Name;

                //    bottomTrans(btn4);
                //    fadeOut();
                //    break;

                ////卡次管理
                //case "btn5":
                //    btnClickedName = (sender as Button).Name;

                //    bottomTrans(btn5);
                //    fadeOut();
                //    break;

                //数据备份
                case "btn6":
                    btnClickedName = (sender as Button).Name;

                    bottomTrans(btn6);
                    fadeOut();
                    break;

                //数据恢复
                case "btn7":
                    btnClickedName = (sender as Button).Name;

                    rightTrans(btn7);
                    fadeOut();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 利用VisualTreeHelper寻找指定依赖对象的父级对象
        /// </summary>
        private static List<T> FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            try
            {
                List<T> TList = new List<T> { };
                DependencyObject parent = VisualTreeHelper.GetParent(obj);
                if (parent != null && parent is T)
                {
                    TList.Add((T)parent);
                    List<T> parentOfParent = FindVisualParent<T>(parent);
                    if (parentOfParent != null)
                    {
                        TList.AddRange(parentOfParent);
                    }
                }
                else if (parent != null)
                {
                    List<T> parentOfParent = FindVisualParent<T>(parent);
                    if (parentOfParent != null)
                    {
                        TList.AddRange(parentOfParent);
                    }
                }
                return TList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 左移动画
        /// </summary>
        private void leftTrans(Button button)
        {
            TranslateTransform translate = new TranslateTransform();
            button.RenderTransform = translate;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);

            //设置动画路径
            PathFigure pathFigure = new PathFigure();
            pathFigure.IsClosed = false;//此值设为 false，则为单向动画
            pathFigure.StartPoint = new Point(0, 0);
            pathFigure.Segments.Add(new LineSegment(new Point(-50, 0), true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path();
            path.Data = pathGeometry;

            //声明路径动画
            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
            animationX.PathGeometry = path.Data.GetFlattenedPathGeometry();
            animationX.Source = PathAnimationSource.X;
            animationX.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(animationX, "translate");
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));

            //storyboard.Completed += Storyboard_Completed;
            storyboard.Children.Add(animationX);
            storyboard.Begin(button);//开始动画
        }

        /// <summary>
        /// 右移动画
        /// </summary>
        private void rightTrans(Button button)
        {
            TranslateTransform translate = new TranslateTransform();
            button.RenderTransform = translate;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);

            //设置动画路径
            PathFigure pathFigure = new PathFigure();
            pathFigure.IsClosed = false;//此值设为 false，则为单向动画
            pathFigure.StartPoint = new Point(0, 0);
            pathFigure.Segments.Add(new LineSegment(new Point(50, 0), true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path();
            path.Data = pathGeometry;

            //声明路径动画
            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
            animationX.PathGeometry = path.Data.GetFlattenedPathGeometry();
            animationX.Source = PathAnimationSource.X;
            animationX.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(animationX, "translate");
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));

            storyboard.Children.Add(animationX);
            storyboard.Begin(button);//开始动画
        }

        /// <summary>
        /// 上移动画
        /// </summary>
        private void topTrans(Button button)
        {
            TranslateTransform translate = new TranslateTransform();
            button.RenderTransform = translate;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);

            //设置动画路径
            PathFigure pathFigure = new PathFigure();
            pathFigure.IsClosed = false;//此值设为 false，则为单向动画
            pathFigure.StartPoint = new Point(0, 0);
            pathFigure.Segments.Add(new LineSegment(new Point(0, -50), true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path();
            path.Data = pathGeometry;

            //声明路径动画
            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();
            animationY.PathGeometry = path.Data.GetFlattenedPathGeometry();
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(animationY, "translate");
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));

            storyboard.Children.Add(animationY);
            storyboard.Begin(button);//开始动画
        }

        /// <summary>
        /// 下移动画
        /// </summary>
        private void bottomTrans(Button button)
        {
            TranslateTransform translate = new TranslateTransform();
            button.RenderTransform = translate;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);

            //设置动画路径
            PathFigure pathFigure = new PathFigure();
            pathFigure.IsClosed = false;//此值设为 false，则为单向动画
            pathFigure.StartPoint = new Point(0, 0);
            pathFigure.Segments.Add(new LineSegment(new Point(0, 50), true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path();
            path.Data = pathGeometry;

            //声明路径动画
            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();
            animationY.PathGeometry = path.Data.GetFlattenedPathGeometry();
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(animationY, "translate");
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));

            storyboard.Children.Add(animationY);
            storyboard.Begin(button);//开始动画
        }

        /// <summary>
        /// 淡出按钮动画
        /// </summary>
        private void fadeOut()
        {
            //淡出动画
            DoubleAnimation daV = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(1000)));
            btn0.BeginAnimation(UIElement.OpacityProperty, daV);
            btn1.BeginAnimation(UIElement.OpacityProperty, daV);
            btn2.BeginAnimation(UIElement.OpacityProperty, daV);
            btn3.BeginAnimation(UIElement.OpacityProperty, daV);
            //btn4.BeginAnimation(UIElement.OpacityProperty, daV);
            //btn5.BeginAnimation(UIElement.OpacityProperty, daV);
            btn6.BeginAnimation(UIElement.OpacityProperty, daV);
            btn7.BeginAnimation(UIElement.OpacityProperty, daV);

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetProperty(daV, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(daV);
            storyboard.Completed += FadeOut_Completed;

            storyboard.Begin(this);//开始动画

            btn0.IsEnabled = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            //btn4.IsEnabled = false;
            //btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;

        }

        /// <summary>
        /// 淡入页动画
        /// </summary>
        public void fadeIn(Page page)
        {
            //淡入动画
            DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(350)));
            page.BeginAnimation(UIElement.OpacityProperty, daV);

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetProperty(daV, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(daV);

            storyboard.Begin(page);//开始动画

        }

        private void FadeOut_Completed(object sender, EventArgs e)
        {
            List<Grid> gridList = FindVisualParent<Grid>(gridContent);
            foreach (Grid item in gridList)
            {
                if (item.Name == "PnlContent")
                {
                    //加载相关页
                    switch (btnClickedName)
                    {
                        //中药开方
                        case "btn0":
                            FirstPages.Page0 page0 = new FirstPages.Page0();
                            fadeIn(page0);

                            item.Children.Add(page0);
                            break;

                        //中药入库
                        case "btn1":
                            Management.Management management = new Management.Management();
                            fadeIn(management);

                            item.Children.Add(management);
                            break;

                        //中药处方管理
                        case "btn2":
                            Management.RxQuery rxQuery = new Management.RxQuery();
                            fadeIn(rxQuery);

                            item.Children.Add(rxQuery);
                            break;

                        ////营业统计
                        //case "btn3":
                        //    Management.BStatis bStatis = new Management.BStatis();
                        //    //fadeIn(bStatis);

                        //    //item.Children.Add(bStatis);
                        //    Process.Start(System.IO.Directory.GetCurrentDirectory()+"/BStatis/index.html");
                        //    break;

                        //办卡
                        case "btn4":
                            CardService.AddCardPage addCardPage = new AddCardPage();
                            fadeIn(addCardPage);

                            item.Children.Add(addCardPage);
                            break;

                        //卡次管理
                        case "btn5":
                            break;

                        //数据迁移
                        case "btn6":
                            DataService.DataBackUp dataBackUp = new DataBackUp();
                            fadeIn(dataBackUp);

                            item.Children.Add(dataBackUp);
                            break;

                        //数据恢复
                        case "btn7":
                            DataService.DataRecover dataRecover = new DataRecover();
                            fadeIn(dataRecover);

                            item.Children.Add(dataRecover);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }
}
