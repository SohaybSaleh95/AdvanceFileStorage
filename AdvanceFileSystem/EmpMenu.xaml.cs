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
        MainWindow MW;

        DoubleAnimation ShowSideBar, HideSideBar, ShowPage;
        Grid Active = null;
        CitizenMenu CitizenPage;
        FilesMenu FilesPage;

        public EmpMenu(string name)
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
            this.EmpName.Content = name;
        }

        public EmpMenu(string name, MainWindow MW)
        {
            InitializeComponent();
            this.MW = MW;
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
            this.EmpName.Content = name;
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
            ((Grid)sender).Background = new SolidColorBrush(Color.FromRgb(4,156,255));
        }

        private void SideBar_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid Current = (Grid)sender;
            if(Current != Active)
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

        private void Citizens_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid Current = (Grid)sender;
            if(Active != Current)
            {
                SetActive(Current);
                Body.Children.Clear();
                Body.Children.Add(CitizenPage);
            }
            
        }

        private void SetActive(Grid grid)
        {
            if(Active != null)
            {
                Active.Background = new SolidColorBrush(Color.FromRgb(41, 128, 185));
            }
            Active = grid;
            grid.Background = new SolidColorBrush(Color.FromRgb(4, 156, 255));
        }
    }
}
