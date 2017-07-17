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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using AdvanceFileSystem.Models;
using System.ComponentModel;

namespace AdvanceFileSystem.Emp
{
    /// <summary>
    /// Interaction logic for Citizens.xaml
    /// </summary>
    public partial class CitizenList : UserControl
    {
        private List<Citizen> Citizens;
        ICollectionView collectionView;

        public CitizenList()
        {
            InitializeComponent();
            FillAddresses();
            FillCitizens();

            collectionView = CollectionViewSource.GetDefaultView(Citizens) as ICollectionView;

            addressComboBox.SelectedIndex = addressComboBox.Items.Count - 1;
        }

        private void FillAddresses()
        {
            List<Address> adds = Connection.GetAddresses();
            addressComboBox.ItemsSource = adds;
            addressComboBox.SelectedValuePath = "Id";
            addressComboBox.DisplayMemberPath = "Name";
            adds.Add(new Address()
            {
                Id = 0,
                Name = "All"
            });
           
        }

        private void FillCitizens()
        {
            if(Citizens != null)
            {
                Citizens.Clear();
            }
            Citizens = Connection.GetCitizens();
            citizensTable.ItemsSource = Citizens;
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            collectionView.Filter = CitizenFilter;
        }

        private bool CitizenFilter(object item)
        {
            try
            {
                string name = nameBox.Text;
                int id;
                int.TryParse(cardIdBox.Text, out id);
                short addressid = (short)addressComboBox.SelectedValue;
                string pobox = poBoxBox.Text;
                string street = streetBox.Text;

                Citizen c = item as Citizen;

                return (c.FullName.Contains(name) && (id == 0 || id == c.Id) && (addressid == 0 || addressid == c.AddressId) && c.PoBox.Contains(pobox) && c.Street.Contains(street));
            }
            catch
            {
                return true;
            }
        }

        private void cardIdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            collectionView.Filter = CitizenFilter;
        }

        private void poBoxBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            collectionView.Filter = CitizenFilter;
        }

        private void streetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            collectionView.Filter = CitizenFilter;
        }

        private void addressComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            collectionView.Filter = CitizenFilter;
        }

        private void citizensTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EmptyWindow ew = new EmptyWindow();
            Citizen cit = (Citizen)citizensTable.SelectedItem;
            if(cit != null)
            {
                AddCitizen ac = new AddCitizen(cit);
                ew.Width = ac.Width + 30;
                ew.Height = ac.Height + 30;
                ac.Margin = new Thickness(0);
                ew.Body.Children.Add(ac);
                ew.Title = "Edit Citizen - " + cit.FullName;
                ew.ShowDialog();
                FillCitizens();
            }
        }
    }
}
