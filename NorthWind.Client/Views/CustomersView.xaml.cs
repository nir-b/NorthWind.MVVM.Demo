using System.Windows.Controls;
using NorthWind.Client.ViewModels;

namespace NorthWind.Client.Views
{
    /// <summary>
    ///     Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        public CustomersView(CustomersViewModel vm) : this()
        {
            DataContext = vm;
        }
    }
}