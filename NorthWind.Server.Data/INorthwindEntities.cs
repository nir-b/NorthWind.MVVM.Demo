using System;
using System.Data.Entity;

namespace NorthWind.Server.Data
{
    public interface INorthwindEntities : IDisposable
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<CustomerDemographic> CustomerDemographics { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Order_Detail> Order_Details { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<Region> Regions { get; set; }
        IDbSet<Shipper> Shippers { get; set; }
        IDbSet<Supplier> Suppliers { get; set; }
        IDbSet<Territory> Territories { get; set; }
    }
}