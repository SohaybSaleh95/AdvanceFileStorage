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
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for EmpMenu.xaml
    /// </summary>
    public partial class EmpMenu : MetroWindow
    {
        private DoubleAnimation SideBarAnimation,
            ShowBodyAnimation,
            HideBodyAnimation;

        private MenuAnimation FilesAnimation,
            CitizensAnimation,
            AddressesAnimation,
            CategoriesAnimation;

        private User User;

        private Label Active { get; set; }

        private UserControl BodyContent;

        public EmpMenu(User user)
        {
            InitializeComponent();
            User = user;
            empNameLabel.Content = User.UserName;
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

            FilesAnimation = new MenuAnimation();
            CitizensAnimation = new MenuAnimation();
            AddressesAnimation = new MenuAnimation();
            CategoriesAnimation = new MenuAnimation();

            
        }

        private void citizensButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            citizensMenuGrid.BeginAnimation(Grid.HeightProperty, CitizensAnimation);
            CitizensAnimation.ReverseAnimation();
            ActiveLabel(sender);
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

        private void filesAddButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void filesListButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void filesButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            filesMenuGrid.BeginAnimation(Grid.HeightProperty, FilesAnimation);
            FilesAnimation.ReverseAnimation();
            ActiveLabel(sender);
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
