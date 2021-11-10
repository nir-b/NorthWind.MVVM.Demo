using System.Reactive.Concurrency;

namespace NorthWind.Client.Infrastructure
{
    public class SchedulerProvider : ISchedulerProvider
    {
        public SchedulerProvider()
        {
            var currentDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            Dispatcher = new DispatcherScheduler(currentDispatcher);
        }

        public IScheduler Dispatcher { get; }


        public IScheduler Concurrent => TaskPoolScheduler.Default;
    }
}