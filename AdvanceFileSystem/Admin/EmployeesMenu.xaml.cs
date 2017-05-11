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
    /// Interaction logic for EmployeesMenu.xaml
    /// </summary>
    public partial class EmployeesMenu : UserControl
    {
        public EmployeesMenu()
        {
            InitializeComponent();
        }

        private void add_employee_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployee().ShowDialog();
        }

        private void employees_list_Button_Click(object sender, RoutedEventArgs e)
        {
            new EmplyeesList().ShowDialog();
        }
    }
}
