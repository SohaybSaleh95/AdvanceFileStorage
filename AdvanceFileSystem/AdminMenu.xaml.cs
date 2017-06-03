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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : MetroWindow
    {
        MainWindow MW;

        DoubleAnimation ShowSideBar, HideSideBar, ShowPage;
        Grid Active = null;
        Admin.LogMenu LogPage;
        Admin.FilesMenu FilesPage;
        Admin.EmployeesMenu EmployeesPage;

        public AdminMenu()
        {
            InitializeComponent();
            ShowSideBar = new DoubleAnimation();
            HideSideBar = new DoubleAnimation();
            //ShowPage = new DoubleAnimation();

            ShowSideBar.From = 26;
            ShowSideBar.To = 150;
            ShowSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            HideSideBar.From = 150;
            HideSideBar.To = 26;
            HideSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            LogPage = new Admin.LogMenu();
            LogPage.Margin = new Thickness(10);
            FilesPage = new Admin.FilesMenu();
            FilesPage.Margin = new Thickness(10);
            EmployeesPage = new Admin.EmployeesMenu();

        }

        public AdminMenu(string EmpName,MainWindow MW)
        {
            InitializeComponent();
            this.MW = MW;
            ShowSideBar = new DoubleAnimation();
            HideSideBar = new DoubleAnimation();
            //ShowPage = new DoubleAnimation();
            this.EmpName.Content = EmpName;
            ShowSideBar.From = 26;
            ShowSideBar.To = 150;
            ShowSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            HideSideBar.From = 150;
            HideSideBar.To = 26;
            HideSideBar.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            LogPage = new Admin.LogMenu();
            LogPage.Margin = new Thickness(10);
            FilesPage = new Admin.FilesMenu();
            FilesPage.Margin = new Thickness(10);
            EmployeesPage = new Admin.EmployeesMenu();

        }

        protected override void OnClosed(EventArgs e)
        {
            MW.Show();
            Close();
        }

        private void SideBar_MouseEnter(object sender, MouseEventArgs e)
        {
            SideBar.BeginAnimation(DataGrid.WidthProperty, ShowSideBar);
        }

        private void SideBar_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Color.FromRgb(4, 156, 255));
        }

        private void SideBar_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid Current = (Grid)sender;
            if (Current != Active)
            {
                Current.Background = new SolidColorBrush(Color.FromRgb(41, 128, 185));
            }
        }

        private void SideBar_MouseLeave(object sender, MouseEventArgs e)
        {
            SideBar.BeginAnimation(DataGrid.WidthProperty, HideSideBar);
        }

        private void Files_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid Current = (Grid)sender;
            if (Active != Current)
            {
                SetActive(Current);
                Body.Children.Clear();
                Body.Children.Add(FilesPage);
            }
        }

        private void Employees_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid Current = (Grid)sender;
            if (Active != Current)
            {
                SetActive(Current);
                Body.Children.Clear();
                Body.Children.Add(EmployeesPage);
            }
        }

        private void Log_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid Current = (Grid)sender;
            if (Active != Current)
            {
                SetActive(Current);
                Body.Children.Clear();
                Body.Children.Add(LogPage);
            }

        }

        private void SetActive(Grid grid)
        {
            if (Active != null)
            {
                Active.Background = new SolidColorBrush(Color.FromRgb(41, 128, 185));
            }
            Active = grid;
            grid.Background = new SolidColorBrush(Color.FromRgb(4, 156, 255));
        }
    }
}
