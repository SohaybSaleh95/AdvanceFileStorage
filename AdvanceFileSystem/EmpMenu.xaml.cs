using MahApps.Metro.Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for EmpMenu.xaml
    /// </summary>
    public partial class EmpMenu : MetroWindow
    {
        private DoubleAnimation SideBarAnimation ,
            ShowBodyAnimation ,
            HideBodyAnimation,
            FilesAnimation,
            CitizensAnimation,
            AddressesAnimation,
            CategoriesAnimation;

        private Label Active { get; set; }

        private UserControl BodyContent;

        public EmpMenu()
        {
            InitializeComponent();
            SideBarAnimation = new DoubleAnimation();


            SideBarAnimation.From = 122;
            SideBarAnimation.To = 50;
            SideBarAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            //SideBarAnimation.AutoReverse = true;

            ShowBodyAnimation = new DoubleAnimation();
            ShowBodyAnimation.From = 0;
            ShowBodyAnimation.To = 1;
            ShowBodyAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            HideBodyAnimation = new DoubleAnimation();
            HideBodyAnimation.From = 1;
            HideBodyAnimation.To = 0;
            HideBodyAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            FilesAnimation = CreateMenuAnimation();
            CitizensAnimation = CreateMenuAnimation();
            AddressesAnimation = CreateMenuAnimation();
            CategoriesAnimation = CreateMenuAnimation();
        }

        private async void citizensButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            citizensMenuGrid.BeginAnimation(Grid.HeightProperty, CitizensAnimation);
            ReverseValues(CitizensAnimation);
            ActiveLabel(sender);
            /*
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(250);
            }
            body.Children.Clear();
            BodyContent = new Emp.AddCitizen();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Width = body.Width;
            BodyContent.Height = body.Height;
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();

            */
        }

        private async void addressesButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(250);
            }
            body.Children.Clear();
            BodyContent = new Emp.Addresses();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Width = body.Width;
            BodyContent.Height = body.Height;
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();

            ActiveLabel(sender);
        }

        private async void citizensAddButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(250);
            }
            body.Children.Clear();
            BodyContent = new Emp.AddCitizen();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Width = body.Width;
            BodyContent.Height = body.Height;
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        private async void citizensListButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(250);
            }
            body.Children.Clear();
            BodyContent = new Emp.CitizenList();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Width = body.Width;
            BodyContent.Height = body.Height;
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }


        /**
         * Create Menu Animation
         * هنا قيم الانميشن نفسهم فبدل ما نكررهم اكثر من مرة 
         * خليناه بفنكشن واستدعيناه لكل قائمة
         *
         **/

        private DoubleAnimation CreateMenuAnimation()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 70;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            return da;
        }

        private void ShowBody()
        {
            BodyContent.BeginAnimation(UserControl.OpacityProperty, ShowBodyAnimation);
        }

        private void HideBody()
        {
            BodyContent.BeginAnimation(UserControl.OpacityProperty, HideBodyAnimation);
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            side_bar.BeginAnimation(Grid.WidthProperty, SideBarAnimation);
        }

        /*
         * Reverse Animation
         * بيعكس قيم الانميشن
         * 
         */
        private void ReverseValues(DoubleAnimation animation)
        {
            double? temp = animation.From;
            animation.From = animation.To;
            animation.To = temp;
        }

        private void ActiveLabel(object label)
        {

            if (Active != null || Active == (Label)label)
            {
                Active.BorderThickness = new Thickness(0);
                Active.Background = new SolidColorBrush(Color.FromRgb(7,162,141));
            }
            
            Active = (Label)label;
            Active.BorderThickness = new Thickness(3, 0, 0, 0);
            Active.BorderBrush = new SolidColorBrush(Color.FromRgb(7, 162, 141));
            Active.Background = new SolidColorBrush(Color.FromRgb(227,247,243));
            
        }
    }
}
