﻿using System;
using Moq;
using NorthWind.Server.Data;
using NorthWind.Tests.Infrastructure;
using NUnit.Framework;

namespace NorthWind.Server.DataRepository.Tests
{
    [TestFixture]
    public class CustomerRespositoryTests
    {
        #region Test Infrastructure
        private Mock<INorthwindEntities> _entitiesContextMock = null;
        private ICustomerRepository _customerRepository = null;

        [SetUp]
        public void TestSetup()
        {
            _entitiesContextMock = new Mock<INorthwindEntities>(MockBehavior.Strict);
            _customerRepository = new CustomerRepository(_entitiesContextMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _customerRepository = null;
            _entitiesContextMock = null;
        }
        #endregion

        [Test]
        public void GetCustomers_Returns_All_Customers()
        {
            var customersInput = new[]
            {
                new Customer{CustomerID = "1"},
                new Customer{CustomerID = "2"},
                new Customer{CustomerID = "3"}
            };

            var customersDbSet = customersInput.AsMockDbSet();
            _entitiesContextMock.Setup(ctx => ctx.Customers).Returns(customersDbSet.Object);

            var customersOutput = _customerRepository.GetCustomers();

            Assert.AreEqual(customersInput.Length, customersOutput.Count);
        }
    }
}
