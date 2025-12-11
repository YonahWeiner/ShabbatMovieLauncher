using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShabbatMovieLauncher.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShabbatMovieLauncher.ViewModels
{
    public class ScheduleItemVM : ObservableObject
    {
        #region Public
        // Enacts the command when schedule button is clicked
        public ICommand SetScheduleButton { get; set; }

        // The scheduled date time selected by user
        private DateTime? _scheduledDateTime;

        public DateTime? ScheduledDateTime
        {
            get { return _scheduledDateTime; }
            set { SetProperty<DateTime?>(ref _scheduledDateTime, value); }
        }

        // url to the movie
        private string _movieUrl = "URL";

        public string MovieUrl
        {
            get { return _movieUrl; }
            set { SetProperty<string>(ref _movieUrl, value); }
        }
        #endregion

        #region Private
        // scheduler to set the time the movie is to be played
        private Scheduler _scheduler = new Scheduler();
        private IMovieLauncher _movieLauncher;
        #endregion

        public ScheduleItemVM(IMovieLauncher movieLauncher) 
        {
            _movieLauncher = movieLauncher;
            SetScheduleButton = new RelayCommand(ExecuteSetScheduleButton);
            ScheduledDateTime = DateTime.Now.AddSeconds(70);
        }

        private async void ExecuteSetScheduleButton()
        {
            if (ScheduledDateTime.HasValue)
            {

                _scheduler.ScheduleAction<string>(((DateTime)ScheduledDateTime).AddMinutes(1),
                    url =>
                    {
                        if (string.IsNullOrWhiteSpace(url))
                        {
                            MessageBox.Show("The url is invalid");
                            return;
                        }

                        PCDisplayWaker.WakeAndClick();
                        System.Threading.Thread.Sleep(1000);
                        App.Current.Dispatcher.Invoke(() => App.Current.MainWindow.Hide());
                        System.Threading.Thread.Sleep(1000);
                        _movieLauncher.Launch(url);

                    }, MovieUrl);
            }
            else
            {
                MessageBox.Show("Please select a valid date and time.");
            }

        }
    }
}
