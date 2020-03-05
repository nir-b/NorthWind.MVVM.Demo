using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Server.Data;

namespace NorthWind.Server.DataRepository
{
    public interface ICustomerRepository : IDisposable
    {
        IList<Customer> GetCustomers();
    }
}
