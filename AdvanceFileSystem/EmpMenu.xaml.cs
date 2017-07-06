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
        private DoubleAnimation SideBarAnimation ,BodyAnimation ,EmpsAnimation;
        public EmpMenu()
        {
            InitializeComponent();
            SideBarAnimation = new DoubleAnimation();

        
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
