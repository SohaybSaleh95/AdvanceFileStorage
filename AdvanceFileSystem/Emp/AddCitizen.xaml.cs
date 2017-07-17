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


namespace AdvanceFileSystem.Emp
{
    /// <summary>
    /// Interaction logic for Citizens.xaml
    /// </summary>
    public partial class AddCitizen : UserControl
    {
        public Citizen AddedCitizen;

        public bool Done = false;

        public AddCitizen()
        {
            InitializeComponent();
            FillAddresses();
            addressComboBox.SelectedIndex = 0;
            //ParentWindow = ((MetroWindow)((Grid)((Grid)this.Parent).Parent).Parent);
        }

        public AddCitizen(Citizen cit)
        {
            InitializeComponent();
            FillAddresses();
            nameBox.Text = cit.FullName;
            cardBox.Text = cit.Id.ToString();
            birthDateBox.Text = cit.BirthDate.ToString("dd/MM/yyyy");
            streettBox.Text = cit.Street;
            poBoxBox.Text = cit.PoBox;
            addressComboBox.SelectedValue = cit.AddressId;
            this.AddedCitizen = cit;
            this.cancelButton.Visibility = Visibility.Visible;
            this.cardId.IsEnabled = false;
        }

        private void FillAddresses()
        {
            addressComboBox.ItemsSource = Connection.GetAddresses();
            addressComboBox.DisplayMemberPath = "Name";
            addressComboBox.SelectedValuePath = "Id";
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fullName = nameBox.Text;
                string cardId = cardBox.Text;
                DateTime? birthDate = birthDateBox.SelectedDate;
                short address = (short)addressComboBox.SelectedValue;
                string street = streettBox.Text;
                string pobox = poBoxBox.Text;
                if (birthDate == null)
                {
                    //ParentWindow.ShowMessageAsync("Error", "Please choose a date");
                    MessageBox.Show("Please Choose a date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //Edit 
                    if(AddedCitizen != null)
                    {
                        int cardIdint;
                        int.TryParse(cardId, out cardIdint);
                        AddedCitizen.Id = cardIdint;
                        AddedCitizen.FullName = fullName;
                        AddedCitizen.BirthDate = birthDate.Value;
                        AddedCitizen.Street = street;
                        AddedCitizen.PoBox = pobox;
                        AddedCitizen.AddressId = address;
                        if (AddedCitizen.IsValid)
                        {
                            if (Connection.UpdateCitizen(AddedCitizen) != 0)
                            {
                                MessageBox.Show("Citizen was edited successfully", "Success");
                                ((MetroWindow)((Grid)this.Parent).Parent).Close();

                            }
                            else
                            {
                                MessageBox.Show("An error occured while editing the citizen \r\n please try again later", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }else
                        {
                            MessageBox.Show(AddedCitizen.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        //Add
                        Citizen cit = new Citizen(fullName, cardId, birthDate.Value, address, street, pobox);
                        if (cit.IsValid)
                        {
                            if (Connection.InsertCitizen(cit) != 0)
                            {
                                //ParentWindow.ShowMessageAsync("Success", "New Citizen was added successfully");
                                MessageBox.Show("New Citizen was added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.None);

                            }
                            else
                            {
                                //ParentWindow.ShowMessageAsync("Error", "An error occured while adding the new citizen \r\n please try again later");
                                MessageBox.Show("An error occured while adding the new citizen \r\n please try again later", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            //ParentWindow.ShowMessageAsync("Error", cit.Error);
                            MessageBox.Show(cit.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            nameBox.Clear();
            cardBox.Clear();
            addressComboBox.SelectedIndex = 0;
            streettBox.Clear();
            poBoxBox.Clear();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            ((MetroWindow)((Grid)this.Parent).Parent).Close();
        }
    }
}
