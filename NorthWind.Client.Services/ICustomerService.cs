using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Server.Data;

namespace NorthWind.Client.Services
{
    public interface ICustomerService
    {
        IObservable<IList<Customer>> GetCustomers();
        void NotifyCustomerSelectionChanged(Customer selectedCustomer);
        IObservable<Customer> CustomerSelectionChanged { get; }
    }
}
