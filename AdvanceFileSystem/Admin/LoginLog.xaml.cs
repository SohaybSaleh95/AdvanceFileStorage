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

namespace AdvanceFileSystem.Admin
{
    /// <summary>
    /// Interaction logic for LoginLog.xaml
    /// </summary>
    public partial class LoginLog : MetroWindow
    {
        public LoginLog()
        {
            InitializeComponent();
            this.dataGrid.Items.Add(new classes.LoginLog()
            {
                Username = "Abdallah",
                LoginTime = "1-5-2017",
                LogoutTime = "1-5-2017"
            });
            this.dataGrid.Items.Add(new classes.LoginLog()
            {
                Username = "Ahmad",
                LoginTime = "1-5-2017",
                LogoutTime = "1-5-2017"
            });
            this.dataGrid.Items.Add(new classes.LoginLog()
            {
                Username = "Aya",
                LoginTime = "1-5-2017",
                LogoutTime = "1-5-2017"
            });

            this.dataGrid.Items.Add(new classes.LoginLog()
            {
                Username = "Raghad",
                LoginTime = "1-5-2017",
                LogoutTime = "1-5-2017"
            });

            this.dataGrid.Items.Add(new classes.LoginLog()
            {
                Username = "Sohayb",
                LoginTime = "1-5-2017",
                LogoutTime = "1-5-2017"
            });
        }
    }
}
