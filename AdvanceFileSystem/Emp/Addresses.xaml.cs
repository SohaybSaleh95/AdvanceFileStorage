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
        //List<Address> addresses;
        private DatabaseContext db = new DatabaseContext();
        public Addresses()
        {
            InitializeComponent();
            FillAddresses();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string address = addressBox.Text;
            Address adress = new Address();
            adress.Name = address;
            if(adress.IsValid)
            {
                db.Addersses.Add(adress);
                db.SaveChanges();
                addressBox.Clear();
                FillAddresses();
            }
            else
            {
                MessageBox.Show(adress.Error);
            }
           // short id = (short)Connection.InsertAddress(address);
            
            //FillAddresses();
        }

        private void FillAddresses ()
        {
            //addresses = Connection.GetAddresses();
            //addresstable.ItemsSource = addresses;

            addresstable.ItemsSource = db.Addersses.ToList();
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
            //يقوم بحذف الاختيار من الجدول
            addresstable.SelectedIndex = -1;

            //اظهار زر الاضافة
            addButton.Visibility = Visibility.Visible;

            //اخفاء زر الحفظ
            saveButton.Visibility = Visibility.Hidden;

            //يمسح ما في داخل صندوق الادرس
            addressBox.Clear();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Address address = (Address)addresstable.SelectedItem;
            address.Name = addressBox.Text;

            //Connection.UpdateAddress(add);

            db.SaveChanges();

            addressBox.Clear();
            FillAddresses();
        }
    }
}
