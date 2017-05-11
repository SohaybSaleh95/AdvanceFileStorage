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
    /// Interaction logic for AddCitizen.xaml
    /// </summary>
    public partial class AddCitizen : MetroWindow
    {
        public AddCitizen()
        {
            InitializeComponent();
        }

        public AddCitizen(classes.Citizen Citiz)
        {
            InitializeComponent();
            id_TxtBox.Text = Citiz.CardId;
            full_name_TxtBox.Text = Citiz.FullName;
            address_ComboBox.SelectedIndex = 0;
            birthdate_DatePicker.Text = Citiz.Birthdate;
        }

        private void clear_Button_Click(object sender, RoutedEventArgs e)
        {
            id_TxtBox.Clear();
            full_name_TxtBox.Clear();
            address_ComboBox.SelectedIndex = 0;
            birthdate_DatePicker.Text = "1-1-1980";
            street_TxtBox.Clear();
            PoBox_TxtBox.Clear();
        }
    }
}
