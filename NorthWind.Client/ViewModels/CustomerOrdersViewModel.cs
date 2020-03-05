using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Client.Services;
using NorthWind.Server.Data;
using Prism.Mvvm;

namespace NorthWind.Client.ViewModels
{
    public class CustomerOrdersViewModel : BindableBase, IDisposable
    {
        private readonly ICustomerService _customerService;
        private IDisposable _customerSelectionChangedSubscription;

        public CustomerOrdersViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            _customerSelectionChangedSubscription = SubscribeToCustomerSelectionChanged();
        }

        private IDisposable SubscribeToCustomerSelectionChanged()
        {
            return _customerService.CustomerSelectionChanged
                .Subscribe(customer => CustomerOrders = customer.Orders.ToList());
        }

        private List<Order> _customerOrders;
        public List<Order> CustomerOrders
        {
            get { return _customerOrders; }
            set
            {
                _customerOrders = value;
                RaisePropertyChanged();
            }
        }


        public void Dispose()
        {
            _customerSelectionChangedSubscription?.Dispose();
        }
    }
}
