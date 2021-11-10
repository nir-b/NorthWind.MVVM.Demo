using System;
using System.Collections.Generic;
using NorthWind.Server.Data;

namespace NorthWind.Server.DataRepository
{
    public interface ICustomerRepository : IDisposable
    {
        IList<Customer> GetCustomers();
    }
}