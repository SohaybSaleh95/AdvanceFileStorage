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
    /// Interaction logic for RequestLog.xaml
    /// </summary>
    public partial class RequestLog : MetroWindow
    {
        public RequestLog()
        {
            InitializeComponent();
            this.dataGrid.Items.Add(new classes.RequestLog()
            {
                EmpName = "SohaybSaleh",
                FileId = 100,
                FileName = "Murder",
                RequestTime = "02-05-2017 8:15 am",
                RequestType = "Get"
            });

            this.dataGrid.Items.Add(new classes.RequestLog()
            {
                EmpName = "SohaybSaleh",
                FileId = 100,
                FileName = "Murder",
                RequestTime = "02-05-2017 8:15 am",
                RequestType = "Get"
            });

            this.dataGrid.Items.Add(new classes.RequestLog()
            {
                EmpName = "SohaybSaleh",
                FileId = 100,
                FileName = "Murder",
                RequestTime = "02-05-2017 8:15 am",
                RequestType = "Get"
            });
        }
    }
}
