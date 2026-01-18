
using System;
using System.Threading;

namespace ShabbatMovieLauncher.Services
{
    public class Scheduler : IScheduler
    {
        Timer _timer;
        public void ScheduleAction<T>(DateTime dateTime, Action<T> action, T args)
        {
          TimeSpan timeToGo = dateTime - DateTime.Now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            if(_timer != null)
            {
                _timer.Dispose();
            }
            _timer = new Timer(x =>
            {
                action(args);
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }
    }
}
