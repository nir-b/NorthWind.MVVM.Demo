using System.Windows;
using NorthWind.Client.Views;
using Prism.Regions;

namespace NorthWind.Client
{
    /// <summary>
    ///     Interaction logic for NorthWindClient.xaml
    /// </summary>
    public partial class NorthWindClient : Window
    {
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