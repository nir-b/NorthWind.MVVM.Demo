using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Client.Infrastructure
{
    public interface ISchedulerProvider
    {
        /// <summary>
        /// Provides access to scheduling onto the UI Dispatcher. 
        /// </summary>
        IScheduler Dispatcher { get; }

        /// <summary>
        /// Provides concurrent scheduling. Will use the thread pool or the task pool if available.
        /// </summary>
        IScheduler Concurrent { get; }
    }
}
