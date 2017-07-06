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
using MahApps.Metro.Controls.Dialogs;

namespace AdvanceFileSystem.Admin
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : MetroWindow
    {
        public AddEmployee()
        {
            InitializeComponent();

        }

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {

            string UserName = username_TxtBox.Text;
            string Password = passwordBox.Password;
            string Email = email_TxtBox.Text;
            string CardId = card_id_TxtBox.Text;
            string Permission = perission_TxtBox.Text;
            string BirthDate = birth_date.Text;

            Password = Extra.Encrypt.MD5(Password);

            if (Extra.StringTools.AnyEmpty(UserName,Password,Email,CardId,Permission,BirthDate))
            {
                this.ShowMessageAsync("ERROR ",Extra.Errors.FieldEmpty);

            }else
            {
                int card_id, permission;
                if(int.TryParse(CardId,out card_id) && int.TryParse(Permission,out permission)  && (permission > 0 && permission <= 100))
                {
                    MySqlConnection conn = Connection.Connect();
                    MySqlCommand cmd = conn.CreateCommand();
                    string query = " INSERT INTO users (username,password,email,card_id,permission,birthdate,address_id) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                    cmd.CommandText = string.Format(query, UserName, Password, Email, CardId, Permission, BirthDate, 1);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    this.ShowMessageAsync("ERROR", Extra.Errors.Invalid);
                }
            }

            
        }
    }
}
