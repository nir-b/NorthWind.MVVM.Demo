using System.Reactive.Concurrency;
using NorthWind.Client.Infrastructure;

namespace NorthWind.Tests.Infrastructure
{
    public class ImmediateSchedulerProvider : ISchedulerProvider
    {
        public IScheduler Dispatcher => Scheduler.Immediate;


        public IScheduler Concurrent => Scheduler.Immediate;
    }
}