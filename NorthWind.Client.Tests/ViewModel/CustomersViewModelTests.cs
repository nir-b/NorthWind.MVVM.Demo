using System.Reactive.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Client.ViewModels;
using NorthWind.Server.Data;
using NorthWind.Tests.Infrastructure;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NorthWind.Client.Tests.ViewModel
{
    [TestClass]
    public class CustomersViewModelTests
    {
        [Test]
        public void CustomerViewModel_Initializes_With_AllCustomers()
        {
            var customersInput = new[]
            {
                new Customer {CustomerID = "1"},
                new Customer {CustomerID = "2"},
                new Customer {CustomerID = "3"}
            };

            _customerServiceMock.Setup(svc => svc.GetCustomers()).Returns(Observable.Return(customersInput));
            _vm = new CustomersViewModel(_schedulerProvider, _customerServiceMock.Object);

            Assert.AreEqual(customersInput.Length, _vm.Customers.Count);
        }

        #region Test Infrastructure

        private ISchedulerProvider _schedulerProvider;
        private Mock<ICustomerService> _customerServiceMock;
        private CustomersViewModel _vm;

        [SetUp]
        public void TestSetup()
        {
            _schedulerProvider = new ImmediateSchedulerProvider();
            _customerServiceMock = new Mock<ICustomerService>();
        }

        [TearDown]
        public void TearDown()
        {
            _vm = null;
            _customerServiceMock = null;
            _schedulerProvider = null;
        }

        #endregion
    }
}