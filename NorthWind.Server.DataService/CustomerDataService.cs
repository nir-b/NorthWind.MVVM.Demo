using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Server.Data;
using NorthWind.Server.DataRepository;

namespace NorthWind.Server.DataService
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDataService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IList<Customer>> GetCustomers()
        {
            return await Task.FromResult(_customerRepository.GetCustomers());
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}
