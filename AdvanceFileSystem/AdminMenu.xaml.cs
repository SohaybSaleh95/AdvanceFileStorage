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
        private MenuAnimation DepartmentsAnimation;

        public AdminMenu()
        {
            InitializeComponent();
            DepartmentsAnimation = new MenuAnimation();
        }

        private void departmentsButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            departmentsMenuGrid.BeginAnimation(Grid.HeightProperty, DepartmentsAnimation);
            DepartmentsAnimation.ReverseAnimation();
        }
    }
}
