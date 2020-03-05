using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Client.ViewModels;
using NorthWind.Server.Data;
using NorthWind.Server.DataService;
using NorthWind.Tests.Infrastructure;
using NUnit.Framework;

namespace NorthWind.Client.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        #region Test Infrastructure
        private Mock<ICustomerDataService> _customerDataServiceMock = null;
        private CustomerService _svc = null;

        [SetUp]
        public void TestSetup()
        {
            _customerDataServiceMock = new Mock<ICustomerDataService>();
            _svc = new CustomerService(_customerDataServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _svc = null;
            _customerDataServiceMock = null;
        }
        #endregion

        [Test]
        public void CustomerService_WhenCustomerSelectionIsUpdated_Then_SubscribersReceiveNotification()
        {
            var selectedCustomer = new Customer {CustomerID = "1"};
            var mockObserver = new Mock<IObserver<Customer>>();
            _svc.CustomerSelectionChanged.Subscribe(mockObserver.Object);

            _svc.NotifyCustomerSelectionChanged(selectedCustomer);
            mockObserver.Verify(obs => obs.OnNext(selectedCustomer), Times.Once);
        }
    }
}
