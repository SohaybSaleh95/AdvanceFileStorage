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

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for FilesSearch.xaml
    /// </summary>
    public partial class FilesSearch : MetroWindow
    {
        public FilesSearch()
        {
            InitializeComponent();
            this.dataGrid.Items.Add(new classes.File()
            {
                Id = 100,
                Name = "Murder",
                Desc = "Someone Murdered Someone",
                Category = new classes.Category()
                {
                    Id = 5,
                    Name = "Murder Files"
                }
            });
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            classes.File F = (classes.File)this.dataGrid.SelectedItem;
            new AddFile(F).ShowDialog();
        }
    }
}
