using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Client.Infrastructure
{
    public class SchedulerProvider : ISchedulerProvider
    {
        private readonly IScheduler _dispatcherScheduler;

        public SchedulerProvider()
        {
            var currentDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _dispatcherScheduler = new DispatcherScheduler(currentDispatcher);
        }

        public IScheduler Dispatcher
        {
            get { return _dispatcherScheduler; }
        }


        public IScheduler Concurrent
        {
            get { return TaskPoolScheduler.Default; }
        }
    }
}
