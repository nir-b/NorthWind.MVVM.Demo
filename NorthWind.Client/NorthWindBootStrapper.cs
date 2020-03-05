using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Client.ViewModels;
using NorthWind.Client.Views;
using NorthWind.Server.Data;
using NorthWind.Server.DataRepository;
using NorthWind.Server.DataService;
using Prism.Regions;

namespace NorthWind.Client
{
    public class NorthWindBootStrapper : UnityBootstrapper
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(NorthWindBootStrapper));
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<NorthWindClient>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            _log.Debug("Configuring Unity Container - START");
            base.ConfigureContainer();

            RegisterServicesThatShouldNOTBeHere();

            RegisterClientInfrastructure();
            RegisterClientServices();
            RegisterViewModels();
            RegisterView();

            _log.Debug("Configuring Unity Container - END");
        }

        
        //TODO Temporarily register the server side services here to make them available
        private void RegisterServicesThatShouldNOTBeHere()
        {
            Container.RegisterType<INorthwindEntities, NorthwindEntities>();
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<ICustomerDataService, CustomerDataService>();
        }

        private void RegisterClientInfrastructure()
        {
            Container.RegisterType<ISchedulerProvider, SchedulerProvider>(new ContainerControlledLifetimeManager());
        }

        private void RegisterClientServices()
        {
            Container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());
        }

        private void RegisterViewModels()
        {
            Container.RegisterType<CustomersViewModel>();
            Container.RegisterType<CustomerOrdersViewModel>();
        }


        private void RegisterView()
        {
            Container.RegisterType<CustomersView>();
            Container.RegisterType<CustomerOrdersView>();
        }

        
    }
}
