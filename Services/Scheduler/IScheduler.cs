using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public interface IScheduler
    {
        void ScheduleAction<T>(DateTime dateTime, Action<T> action, T args);
    }
}
