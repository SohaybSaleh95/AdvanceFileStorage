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
using AdvanceFileSystem.classes;

namespace AdvanceFileSystem.Emp.Addresses
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        public Add()
        {
            InitializeComponent();

            address();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string address = addressBox.Text;

            MySqlConnection conn = Connection.Connect();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO address (address) VALUES('" + address + "');";

            cmd.ExecuteNonQuery();
            this.address();
            addressBox.Clear();
        }

        private void address ()
        {
            addresstable.Items.Clear();
            MySqlConnection conn = Connection.Connect();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * FROM address";
            MySqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Address add = new Address();
                add.Id = Reader.GetInt32("id");
                add.Name = Reader.GetString("address");

                addresstable.Items.Add(add);

            }
            Reader.Close();
        }
    }
}
