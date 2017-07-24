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
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Login Page
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {
      private  DatabaseContext db = new DatabaseContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string UserName = userNameBox.Text;
                string Password = passwordBox.Password;
                if (Extra.StringTools.AnyEmpty(UserName, Password))
                {
                    this.ShowMessageAsync("Error", Extra.Errors.FieldEmpty);
                }
                else
                {
                    //MySqlConnection conn = Connection.Connect();
                    //MySqlCommand cmd = conn.CreateCommand();
                    Password = Extra.Encrypt.MD5(Password);
                    //string query = ("select * from users where username = '{0}' and password ='{1}' "); //string format
                    //cmd.CommandText = string.Format(query, UserName, Password);
                    //MySqlDataReader Reader = cmd.ExecuteReader();

                    User user = db.Users.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault() ;
                   if(user != null)
                    {
                        new EmpMenu(user).Show();
                    }
                   else
                    {
                        this.ShowMessageAsync("Error", Extra.Errors.Invalid);
                    }
                    //MySqlDataReader Reader = Connection.ExecuteReader(string.Format(query, UserName, Password));

                    /*if (Reader.HasRows)
                    {
                        Reader.Read();

                        User user = new User()
                        {
                            Id = Reader.GetInt32("id"),
                            UserName = Reader.GetString("username"),
                            Email = Reader.GetString("email"),
                            Admin = Reader.GetBoolean("admin"),
                            Permission = Reader.GetByte("permission"),
                            CardId = Reader.GetInt32("card_id"),
                            BirthDate = Reader.GetDateTime("birthdate")
                        };

                        Reader.Close();
                        if (user.Admin)
                        {
                            new AdminMenu().ShowDialog();
                        }
                        else
                        {
                            new EmpMenu(user).ShowDialog();
                        }
                    }
                    else
                    {
                        Reader.Close();
                        this.ShowMessageAsync("Invalid information", Extra.Errors.Invalid);
                    }*/
                }

            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }

        }

        private void userNameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                button_Click_1(sender, e);
            }
        }
    }
}
