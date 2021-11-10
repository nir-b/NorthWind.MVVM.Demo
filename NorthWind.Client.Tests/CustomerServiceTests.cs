using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NorthWind.Client.Services;
using NorthWind.Server.Data;
using NorthWind.Server.DataService;
using NUnit.Framework;

namespace NorthWind.Client.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [Test]
        public void CustomerService_WhenCustomerSelectionIsUpdated_Then_SubscribersReceiveNotification()
        {
            var selectedCustomer = new Customer {CustomerID = "1"};
            var mockObserver = new Mock<IObserver<Customer>>();
            _svc.CustomerSelectionChanged.Subscribe(mockObserver.Object);

            _svc.NotifyCustomerSelectionChanged(selectedCustomer);
            mockObserver.Verify(obs => obs.OnNext(selectedCustomer), Times.Once);
        }

        #region Test Infrastructure

        private Mock<ICustomerDataService> _customerDataServiceMock;
        private CustomerService _svc;

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
    }
}