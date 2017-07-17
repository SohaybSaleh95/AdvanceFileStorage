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
using MySql.Data.MySqlClient;
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem.Emp
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Addresses : UserControl
    {
        List<Address> addresses;
        public Addresses()
        {
            InitializeComponent();
            FillAddresses();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string address = addressBox.Text;
            short id = (short)Connection.InsertAddress(address);
            addressBox.Clear();
            FillAddresses();
        }

        private void FillAddresses ()
        {
            addresses = Connection.GetAddresses();
            addresstable.ItemsSource = addresses;
        }

        private void addresstable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Address address = (Address)addresstable.SelectedItem;
            if(address != null)
            {
                addButton.Visibility = Visibility.Hidden;
                saveButton.Visibility = Visibility.Visible;
                addressBox.Text = address.Name;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            addresstable.SelectedIndex = -1;
            addButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Hidden;
            addressBox.Text = "";
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Address add = (Address)addresstable.SelectedItem;
            add.Name = addressBox.Text;
            Connection.UpdateAddress(add);
            addressBox.Clear();
            FillAddresses();
        }
    }
}
