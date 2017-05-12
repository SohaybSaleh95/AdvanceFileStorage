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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //بياخذ اسم المستخدم 
                //Trim تقوم بحذف المسافات من الاسم
                string username = user_name_TxtBox.Text.Trim();

                //بياخذ الباسوورد
                string password = password_TxtBox.Password;

                //يتحقق اذا المستخدم كتب اسم وكلمة سر عن طريق طول النص
                if (username.Length == 0 || password.Length == 0)
                {
                    this.ShowMessageAsync("Error", Extra.Errors.FieldEmpty);
                }
                else
                {
                    //اول شي ناخذ الاتصال من الكلاس يلي سويناها
                    MySqlConnection Conn = Connection.Connect();

                    //ثاني شيء ننشء الامر يلي بدنا نطبقه عالداتا بيس
                    MySqlCommand cmd = Conn.CreateCommand();

                    //الباسوورد مخزنة بتشفير md5 فلازم نشفرها قبل ما نفحص بالداتا بيس
                    password = Extra.Encrypt.MD5(password);

                    //نعطيه نص الكويري
                    cmd.CommandText = "SELECT * FROM users WHERE username = '" + username + "' and password = '" + password + "';";

                    //تطبيق الكويري بيتخزن باشي اسمه MySqlDataReader
                    MySqlDataReader _Reader = cmd.ExecuteReader();

                    //هيك نكون اخذنا الاسطر يلي بالداتا بيس يلي اليوزر نيم والباسوورد مثل ما ادخل المستخدم
                    //عشان نشوف اذا موجود ولا لا ناخذ خاصية HasRows
                    if (_Reader.HasRows) //اذا تحقق الشرط معناها انه فعلا موجود سطر بهاي المعلومات
                    {
                        this.ShowMessageAsync("Success", "Login Successfull");
                    }
                    else
                    {
                        this.ShowMessageAsync("Fail", "Login Failed \r\n Username or password isnt correct");
                    }

                    //وهون نغلقه
                    _Reader.Close();
                }
            }
            catch(Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }
        }
    }
}
