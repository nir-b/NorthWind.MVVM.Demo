using System.Windows;
using log4net;
using Microsoft.Practices.Unity;
using NorthWind.Client.Infrastructure;
using NorthWind.Client.Services;
using NorthWind.Client.ViewModels;
using NorthWind.Client.Views;
using NorthWind.Server.Data;
using NorthWind.Server.DataRepository;
using NorthWind.Server.DataService;
using Prism.Unity;

namespace NorthWind.Client
{
    public class NorthWindBootStrapper : UnityBootstrapper
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(NorthWindBootStrapper));

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