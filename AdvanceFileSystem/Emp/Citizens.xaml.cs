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
    /// Interaction logic for Citizens.xaml
    /// </summary>
    public partial class Citizens : UserControl
    {
        public Citizens()
        {
            InitializeComponent();

            MySqlDataReader Reader = Connection.ExecuteReader("select * from citizens");
            while (Reader.Read())
            {
                Citizen cit = new Citizen();
                cit.BirthDate = Reader.GetDateTime("birthdate");
                cit.FullName = Reader.GetString("full_name");
                cit.Id = Reader.GetInt32("id");
                cit.PoBox = Reader.GetString("pobox");
                cit.Street = Reader.GetString("street");
                citizenTable.Items.Add(cit);
            }

            Reader.Close();
           
        }

        private void citizenTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Citizen cit = (Citizen)citizenTable.SelectedItem;
            nameBox.Text = cit.FullName;
            cardBox.Text = cit.Id.ToString();
            birthDate.Text = cit.BirthDate.ToString();
            streettBox.Text = cit.Street.ToString();
            poBox1.Text = cit.PoBox.ToString();
            save.Content = "Update";
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
