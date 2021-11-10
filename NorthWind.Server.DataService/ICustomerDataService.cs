using System.Collections.Generic;
using System.Threading.Tasks;
using NorthWind.Server.Data;

namespace NorthWind.Server.DataService
{
    public interface ICustomerDataService
    {
        Task<IList<Customer>> GetCustomers();
    }
}