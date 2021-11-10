using System;
using System.Collections.Generic;
using NorthWind.Server.Data;

namespace NorthWind.Client.Services
{
    public interface ICustomerService
    {
        IObservable<Customer> CustomerSelectionChanged { get; }
        IObservable<IList<Customer>> GetCustomers();
        void NotifyCustomerSelectionChanged(Customer selectedCustomer);
    }
}