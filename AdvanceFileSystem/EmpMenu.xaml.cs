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

        //Show Citizens Menu
        private void showCitizensMenuButton_Click(object sender, RoutedEventArgs e)
        {
            citizensMenu.BeginAnimation(Grid.HeightProperty, CitizensAnimation);
            ReverseValues(CitizensAnimation);
        }

        //Show Addresses Menu
        private void showAddressesMenuButton_Click(object sender, RoutedEventArgs e)
        {
            addressesMenu.BeginAnimation(Grid.HeightProperty, AddressesAnimation);
            ReverseValues(AddressesAnimation);
        }

        //Show Categories
        private void showCategoriesMenuButton_Click(object sender, RoutedEventArgs e)
        {
            categoriesMenu.BeginAnimation(Grid.HeightProperty, CategoriesAnimation);
            ReverseValues(CategoriesAnimation);
        }

        //Show Add file Interface
        private async void filesAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Files.Add();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show Files List
        private async void filesListButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Files.List();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show Add Citizen Interface
        private async void citizensAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Citizens.Add();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show Citizens List intergace
        private async void citizensListButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Citizens.List();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show Add address Interface
        private async void addressesAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Addresses.Add();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show addresses list interface
        private async void addressesListButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Addresses.List();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show add Categories interface
        private async void categoriesAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Addresses.List();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show categories list interface
        private async void categoriesListButton_Click(object sender, RoutedEventArgs e)
        {
            if (BodyContent != null)
            {
                HideBody();
                await Task.Delay(500);
            }
            body.Children.Clear();
            BodyContent = new Emp.Categories.Add();
            BodyContent.Margin = new Thickness(0);
            BodyContent.Opacity = 0;
            body.Children.Add(BodyContent);
            ShowBody();
        }

        //Show files Menu
        private void showFilesMenuButton_Click(object sender, RoutedEventArgs e)
        {
            filesMenu.BeginAnimation(Grid.HeightProperty, FilesAnimation);
            ReverseValues(FilesAnimation);
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
            da.From = 35;
            da.To = 105;
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
    }
}
