﻿using MahApps.Metro.Controls;
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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : MetroWindow
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        
        public AddEmployee(classes.Employee Emp)
        {
            InitializeComponent();
            username_TxtBox.Text = Emp.Name;
            card_id_TxtBox.Text = Emp.CardId.ToString();
            perission_TxtBox.Text = Emp.Permission.ToString();
        }
    }
}
