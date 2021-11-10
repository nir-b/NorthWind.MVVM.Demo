using System.Windows.Controls;
using NorthWind.Client.ViewModels;

namespace NorthWind.Client.Views
{
    /// <summary>
    ///     Interaction logic for CustomerOrdersView.xaml
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