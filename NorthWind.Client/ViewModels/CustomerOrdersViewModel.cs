using System;
using System.Collections.Generic;
using System.Linq;
using NorthWind.Client.Services;
using NorthWind.Server.Data;
using Prism.Mvvm;

namespace NorthWind.Client.ViewModels
{
    public class CustomerOrdersViewModel : BindableBase, IDisposable
    {
        private readonly ICustomerService _customerService;

        private List<Order> _customerOrders;
        private readonly IDisposable _customerSelectionChangedSubscription;

        public CustomerOrdersViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            _customerSelectionChangedSubscription = SubscribeToCustomerSelectionChanged();
        }

        public List<Order> CustomerOrders
        {
            get => _customerOrders;
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

        private IDisposable SubscribeToCustomerSelectionChanged()
        {
            return _customerService.CustomerSelectionChanged
                .Subscribe(customer => CustomerOrders = customer.Orders.ToList());
        }
    }
}