using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Client.Infrastructure;

namespace NorthWind.Tests.Infrastructure
{
    public class ImmediateSchedulerProvider : ISchedulerProvider
    {
        public IScheduler Dispatcher
        {
            get { return Scheduler.Immediate; }
        }


        public IScheduler Concurrent
        {
            get { return Scheduler.Immediate; }
        }
    }
}
