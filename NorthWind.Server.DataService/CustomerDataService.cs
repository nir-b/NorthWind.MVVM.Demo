using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using NorthWind.Server.Data;
using NorthWind.Server.DataRepository;

namespace NorthWind.Server.DataService
{
    public class CustomerDataService : ICustomerDataService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CustomerDataService));

        private readonly ICustomerRepository _customerRepository;

        public CustomerDataService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            _log.Info("Invoked CustomerDataService.GetCustomers()");
            return await Task.FromResult(_customerRepository.GetCustomers());
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}