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
    /// Interaction logic for ApproveFiles.xaml
    /// </summary>
    public partial class ApproveFiles : MetroWindow
    {
        public ApproveFiles()
        {
            InitializeComponent();

            this.dataGrid.Items.Add(new classes.File()
            {
                Id = 5,
                Name = "Murder",
                AddedTime = "1-5-2017",
                Category = new classes.Category() { Id = 1,Name = "Murder Files"},
                User = new classes.User() { Id= 1,Name="Sohayb"},
                Desc = "Welcome"
            });

            this.dataGrid.Items.Add(new classes.File()
            {
                Id = 6,
                Name = "Murder",
                AddedTime = "1-5-2017",
                Category = new classes.Category() { Id = 1, Name = "Murder Files" },
                User = new classes.User() { Id = 1, Name = "Sohayb" },
                Desc = "Welcome"
            });
        }
    }
}
