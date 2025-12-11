using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public sealed class ScheduleClicked 
    {
        public DateTime MovieTime { get; set; }
        public string Url { get; set; }
    }
    public sealed class EditClicked { }
}
