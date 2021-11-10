using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using NorthWind.Server.Data;
using NorthWind.Server.DataService;

namespace NorthWind.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataService _customerDataService;
        private readonly ISubject<Customer> _selectedCustomerChanged;

        public CustomerService(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
            _selectedCustomerChanged = new Subject<Customer>();
        }

        public IObservable<IList<Customer>> GetCustomers()
        {
            return Observable.FromAsync(() => _customerDataService.GetCustomers());
        }

        public void NotifyCustomerSelectionChanged(Customer selectedCustomer)
        {
            _selectedCustomerChanged.OnNext(selectedCustomer);
        }

        public IObservable<Customer> CustomerSelectionChanged => _selectedCustomerChanged;
    }
}