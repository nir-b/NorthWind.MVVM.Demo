using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Server.Data;

namespace NorthWind.Server.DataRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly INorthwindEntities _entitiesContext;

        public CustomerRepository(INorthwindEntities entitiesContext)
        {
            _entitiesContext = entitiesContext;
        }
        public IList<Customer> GetCustomers()
        {
            var result = _entitiesContext.Customers.Include(c => c.Orders).AsNoTracking();
            return result.ToList();
        }

        public void Dispose()
        {
            _entitiesContext?.Dispose();
        }
    }
}
