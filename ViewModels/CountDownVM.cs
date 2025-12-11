using System;
using System.Windows.Threading;

using CommunityToolkit.Mvvm.ComponentModel;

namespace ShabbatMovieLauncher.ViewModels
{
    public class CountDownVM : ObservableObject
    {
        // url to the movie
        private string _timeText = "hh:mm:ss";

        public string TimeText
        {
            get { return _timeText; }
            set { SetProperty<string>(ref _timeText, value); }
        }

        private DispatcherTimer _timer;
        private DateTime _movieSchedule;

        public CountDownVM()
        {
            TimeText = DateTime.Now.ToLongTimeString();
            _timer = new DispatcherTimer();
            _timer.Interval = new System.TimeSpan(0, 0, 0, 0, 100);
            _timer.Tick += _timer_Tick;
            _timer.Start();

            _movieSchedule = DateTime.Now.AddHours(18).AddMinutes(24);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeDiff = DateTime.Now - _movieSchedule;
            TimeText = -1*timeDiff.Hours + ":" + -1*timeDiff.Minutes + ":" + -1*timeDiff.Seconds;
        }
    }

    
}
