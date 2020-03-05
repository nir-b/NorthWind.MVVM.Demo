﻿using System;
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
using NorthWind.Client.ViewModels;

namespace NorthWind.Client.Views
{
    /// <summary>
    /// Interaction logic for CustomerOrdersView.xaml
    /// </summary>
    public partial class CustomerOrdersView : UserControl
    {
        public CustomerOrdersView()
        {
            InitializeComponent();
        }

        public CustomerOrdersView(CustomerOrdersViewModel vm) : this()
        {
            DataContext = vm;
        }
    }
}
