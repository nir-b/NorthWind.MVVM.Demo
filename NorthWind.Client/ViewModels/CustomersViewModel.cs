using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.Practices.ObjectBuilder2;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Server.Data;
using NorthWind.Server.DataService;
using Prism.Mvvm;

namespace NorthWind.Client.ViewModels
{
    public class CustomersViewModel : BindableBase, IDisposable
    {
        private readonly ISchedulerProvider _schedulerProvider;
        private readonly ICustomerService _customerService;
        private IDisposable _customerSubscription;

        public CustomersViewModel(ISchedulerProvider schedulerProvider, ICustomerService customerService)
        {
            _schedulerProvider = schedulerProvider;
            _customerService = customerService;
            GetAllCustomers();
        }

        private void GetAllCustomers()
        {
            _customerSubscription =_customerService.GetCustomers()
                    .SubscribeOn(_schedulerProvider.Concurrent)
                    .ObserveOn(_schedulerProvider.Dispatcher)
                    .Subscribe(customers => customers.ForEach(Customers.Add));
        }

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        private Customer _customer;
        public Customer SelectedCustomer
        {
            get { return _customer; }
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
    }
}
