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

namespace AdvanceFileSystem
{
    /// <summary>
    /// Interaction logic for FilesMenu.xaml
    /// </summary>
    public partial class FilesMenu : UserControl
    {
        public FilesMenu()
        {
            InitializeComponent();
        }

        private void add_File_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddFile().ShowDialog();
        }

        private void file_Search_Button_Click(object sender, RoutedEventArgs e)
        {
            new FilesSearch().ShowDialog();
        }
    }
}
