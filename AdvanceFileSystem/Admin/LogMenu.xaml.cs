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

namespace AdvanceFileSystem.Admin
{
    /// <summary>
    /// Interaction logic for LogMenu.xaml
    /// </summary>
    public partial class LogMenu : UserControl
    {
        public LogMenu()
        {
            InitializeComponent();
        }

        private void login_log_Button_Click(object sender, RoutedEventArgs e)
        {
            new LoginLog().ShowDialog();
        }

        private void request_log_Button_Click(object sender, RoutedEventArgs e)
        {
            new RequestLog().ShowDialog();
        }
    }
}
