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

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for CitizenSearch.xaml
    /// </summary>
    public partial class CitizenSearch : MetroWindow
    {
        public CitizenSearch()
        {
            InitializeComponent();
            this.dataGrid.Items.Add(new classes.Citizen() { CardId = "11111", FullName = "Sohayb Saleh", Address = "Jenin", Birthdate = "18-12-1995" });
            this.dataGrid.Items.Add(new classes.Citizen() { CardId = "22222", FullName = "Sohayb Saleh", Address = "Jenin", Birthdate = "18-12-1995" });
            this.dataGrid.Items.Add(new classes.Citizen() { CardId = "23333", FullName = "Sohayb Saleh", Address = "Jenin", Birthdate = "18-12-1995" });
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            classes.Citizen Citi = (classes.Citizen)dataGrid.SelectedItem;
            new AddCitizen(Citi).ShowDialog();
        }
    }
}
