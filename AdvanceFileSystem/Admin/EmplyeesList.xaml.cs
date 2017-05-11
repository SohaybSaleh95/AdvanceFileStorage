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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdvanceFileSystem.Admin
{
    /// <summary>
    /// Interaction logic for EmplyeesList.xaml
    /// </summary>
    public partial class EmplyeesList : MetroWindow
    {
        public EmplyeesList()
        {
            InitializeComponent();
            this.dataGrid.Items.Add(new classes.Employee()
            {
                CardId = 201311056,
                Name = "Abdallah Samoudi",
                Address = "Jenin"
            });
            this.dataGrid.Items.Add(new classes.Employee()
            {
                CardId = 201311056,
                Name = "Ahmad Omaria",
                Address = "Jenin"
            });
            this.dataGrid.Items.Add(new classes.Employee()
            {
                CardId = 201311056,
                Name = "Aya Jabir",
                Address = "Tulkarem"
            });
            this.dataGrid.Items.Add(new classes.Employee()
            {
                CardId = 201311056,
                Name = "Raghad Numan",
                Address = "Tulkarem"
            });
            this.dataGrid.Items.Add(new classes.Employee()
            {
                CardId = 201311056,
                Name = "Sohayb Saleh",
                Address = "Jenin"
            });
        }

        private void Active_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Button_Click(object sender,RoutedEventArgs e)
        {
            classes.Employee Emp = (classes.Employee)dataGrid.SelectedItem;
            new AddEmployee(Emp).ShowDialog();
        }
    }
}
