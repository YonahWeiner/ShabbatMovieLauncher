using System;
using System.Windows.Input;
using System.Windows.Threading;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShabbatMovieLauncher.Services;

namespace ShabbatMovieLauncher.ViewModels
{
    public class CountDownVM : ObservableObject
    {
        // Enacts the command when edit button is clicked
        public ICommand EditButtonCommand { get; set; }

        // url to the movie
        private string _timeText = "hh:mm:ss";

        public string TimeText
        {
            get { return _timeText; }
            set { SetProperty<string>(ref _timeText, value); }
        }

        // timer to update countdown text
        private DispatcherTimer _timer;

        // scheduled movie time
        private DateTime _movieSchedule;

        public CountDownVM()
        {
            //initialize
            TimeText = DateTime.Now.ToLongTimeString();

            // timer updates time text every 100 milliseconds
            _timer = new DispatcherTimer();
            _timer.Interval = new System.TimeSpan(0, 0, 0, 0, 100);
            _timer.Tick += _timer_Tick;
            _timer.Start();

            // default movie schedule time for testing
            _movieSchedule = DateTime.Now.AddHours(18).AddMinutes(24);
            // command for edit button
            EditButtonCommand = new RelayCommand(OnEditButtonClicked);

            // listen for schedule clicked message to get the scheduled time
            WeakReferenceMessenger.Default.Register<ScheduleClicked>(this, (sender, args) =>
            {
                _movieSchedule = args.MovieTime;
            });
        }

        private void OnEditButtonClicked()
        {
            WeakReferenceMessenger.Default.Send<EditClicked>();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeDiff = DateTime.Now - _movieSchedule;
            if (timeDiff.TotalSeconds >= 0)
            {
                TimeText = "Movie Begins Soon...";
                return;
            }

            TimeText = (-1 * timeDiff.Hours).ToString("00") + ":"
                + (-1 * timeDiff.Minutes).ToString("00") + ":" 
                + (-1 * timeDiff.Seconds).ToString("00");
        }
    }

    
}
