using System;

namespace ShabbatMovieLauncher.Services
{
    public sealed class ScheduleClicked 
    {
        public DateTime MovieTime { get; set; }
        public string Url { get; set; }
    }
    public sealed class EditClicked { }
}
