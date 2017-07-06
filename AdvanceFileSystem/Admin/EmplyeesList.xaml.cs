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
using MySql.Data.MySqlClient;
using AdvanceFileSystem.classes;


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
            MySqlConnection conn = Connection.Connect();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * FROM users";
            MySqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Employee emp = new Employee();
                emp.Address = "";
                emp.CardId = Reader.GetInt32("card_id");
                emp.Name = Reader.GetString("username");
                emp.Permission = Reader.GetInt32("permission");
                emptable.Items.Add(emp);
            }
        }
    }
}
