﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using NorthWind.Client.Views;
using Prism.Regions;

namespace NorthWind.Client
{
    /// <summary>
    /// Interaction logic for NorthWindClient.xaml
    /// </summary>
    public partial class NorthWindClient : Window
    {
        private readonly IRegionManager _regionManager;

        public NorthWindClient(IRegionManager regionManager)
        {
            InitializeComponent();
            
            RegisterViewWithRegion(regionManager);
        }

        private void RegisterViewWithRegion(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("CustomersRegion", typeof(CustomersView));
            regionManager.RegisterViewWithRegion("OrdersRegion", typeof(CustomerOrdersView));
        }
    }
}
