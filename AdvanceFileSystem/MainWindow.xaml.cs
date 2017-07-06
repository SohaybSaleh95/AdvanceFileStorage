using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Login Page
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            string UserName = userNameBox.Text;
            string Password = passwordBox.Password;
            if (Extra.StringTools.AnyEmpty(UserName, Password))
            {
                this.ShowMessageAsync("Error", "Username or Password are Empty");
            }else
            {
                MySqlConnection conn = Connection.Connect();
                MySqlCommand cmd = conn.CreateCommand();
                Password = Extra.Encrypt.MD5(Password);
                string query = ("select * from users where username = '{0}' and password ='{1}' "); //string format
                cmd.CommandText = string.Format(query, UserName, Password);

                MySqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    Reader.Read();
                    
                    if(Reader["admin"].ToString()=="1")
                    {
                        Reader.Close();
                        new AdminMenu().Show();

                    }
                    else
                    {
                        Reader.Close();
                        new EmpMenu().Show();
                    }
                }
                else
                {
                    this.ShowMessageAsync("Invalid information", Extra.Errors.Invalid);
                }
                   
            }
        }
    }
}
