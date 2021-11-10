using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Microsoft.Practices.ObjectBuilder2;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Server.Data;
using Prism.Mvvm;

namespace NorthWind.Client.ViewModels
{
    public class CustomersViewModel : BindableBase, IDisposable
    {
        private readonly ICustomerService _customerService;
        private readonly ISchedulerProvider _schedulerProvider;

        private Customer _customer;
        private IDisposable _customerSubscription;

        public CustomersViewModel(ISchedulerProvider schedulerProvider, ICustomerService customerService)
        {
            _schedulerProvider = schedulerProvider;
            _customerService = customerService;
            GetAllCustomers();
        }

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        public Customer SelectedCustomer
        {
            get => _customer;
            set
            {
                _customer = value;
                _customerService.NotifyCustomerSelectionChanged(value);
            }
        }

        public void Dispose()
        {
            _customerSubscription?.Dispose();
        }

        private void GetAllCustomers()
        {
            _customerSubscription = _customerService.GetCustomers()
                .SubscribeOn(_schedulerProvider.Concurrent)
                .ObserveOn(_schedulerProvider.Dispatcher)
                .Subscribe(customers => customers.ForEach(Customers.Add));
        }
    }
}