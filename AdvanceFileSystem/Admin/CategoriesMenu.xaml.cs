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
    /// Interaction logic for CategoriesMenu.xaml
    /// </summary>
    public partial class CategoriesMenu : MetroWindow
    {
        public CategoriesMenu()
        {
            InitializeComponent();

            this.dataGrid.Items.Add(new classes.Category()
            {
                Id = 1,
                Name = "Murder Files"
            });

            this.dataGrid.Items.Add(new classes.Category()
            {
                Id = 2,
                Name = "Murder Files"
            });
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            name_TxtBox.Clear();
            dataGrid.SelectedIndex = -1;
            add_Button.Content = "Add";
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                add_Button.Content = "Edit";
                name_TxtBox.Text = ((classes.Category)dataGrid.SelectedItem).Name;
            }
        }
    }
}
