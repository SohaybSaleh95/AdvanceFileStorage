using MahApps.Metro.Controls;
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

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for EmpMenu.xaml
    /// </summary>
    public partial class EmpMenu : MetroWindow
    {
<<<<<<< HEAD
        private DoubleAnimation SideBarAnimation ,BodyAnimation ,EmpsAnimation;
        public EmpMenu()
        {
            InitializeComponent();
            SideBarAnimation = new DoubleAnimation();
=======
        MainWindow MW;

        DoubleAnimation ShowSideBar, HideSideBar, ShowPage;
        Grid Active = null;
        CitizenMenu CitizenPage;
        FilesMenu FilesPage;

        public EmpMenu()
        {
            InitializeComponent();
            ShowSideBar = new DoubleAnimation();
            HideSideBar = new DoubleAnimation();
            ShowPage = new DoubleAnimation();

            ShowSideBar.From = 26;
            ShowSideBar.To = 150;
            ShowSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            HideSideBar.From = 150;
            HideSideBar.To = 26;
            HideSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            ShowPage.From = 0;
            ShowPage.To = 1;
            ShowPage.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            CitizenPage = new CitizenMenu();
            CitizenPage.Margin = new Thickness(10);
            FilesPage = new FilesMenu();
            FilesPage.Margin = new Thickness(10);
        }
        
        private void SideBar_MouseEnter(object sender, MouseEventArgs e)
        {
            SideBar.BeginAnimation(DataGrid.WidthProperty, ShowSideBar);
        }
>>>>>>> b07d9141d957eee4c7027ae4b4b9f10489ba6c59

            SideBarAnimation.From = 122;
            SideBarAnimation.To = 50 ;
            SideBarAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            //SideBarAnimation.AutoReverse = true;

            BodyAnimation = new DoubleAnimation();
            BodyAnimation.From = 412;
            BodyAnimation.To = 484;
            BodyAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            BodyAnimation.AutoReverse = true;

            EmpsAnimation = new DoubleAnimation();
            EmpsAnimation.From =0;
            EmpsAnimation.To =57;
            EmpsAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            EmpsAnimation.AutoReverse = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            emps.BeginAnimation(Grid.HeightProperty, EmpsAnimation);
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            side_bar.BeginAnimation(Grid.WidthProperty, SideBarAnimation);
            body.BeginAnimation(Grid.WidthProperty, BodyAnimation);
        }

        
    }
}
