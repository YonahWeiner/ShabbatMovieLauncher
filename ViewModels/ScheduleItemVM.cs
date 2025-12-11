using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShabbatMovieLauncher.Services;
using System;
using System.Security.Policy;
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
            // initialize
            _movieLauncher = movieLauncher;
            SetScheduleButton = new RelayCommand(ExecuteSetScheduleButton);
            ScheduledDateTime = DateTime.Now.AddSeconds(70);
        }

        private async void ExecuteSetScheduleButton()
        {
            if (ScheduledDateTime.HasValue)
            {
                if (string.IsNullOrWhiteSpace(MovieUrl))
                {
                    MessageBox.Show("The url is invalid");
                    return;
                }
                // schedule launch movie
                _scheduler.ScheduleAction<string>(((DateTime)ScheduledDateTime).AddMinutes(1),
                    url =>
                    {
                        // wake up display if screen turn off. click to open windows drop down screen
                        PCDisplayWaker.WakeAndClick();  
                        
                        // give time for computer to react
                        System.Threading.Thread.Sleep(1000); 
                        
                        // hide main window not to block the movie. right now this leaves the exe running, but shutting it down
                        // causes unpredictable behaivior if movie is external browser. todo: fix
                        App.Current.Dispatcher.Invoke(() => App.Current.MainWindow.Hide());                                      
                        System.Threading.Thread.Sleep(1000);

                        // launch movie
                        _movieLauncher.Launch(url);

                    }, MovieUrl);
                WeakReferenceMessenger.Default.Send<ScheduleClicked>(new ScheduleClicked() { Url = MovieUrl, MovieTime = (DateTime)ScheduledDateTime });
            }
            else
            {
                MessageBox.Show("Please select a valid date and time.");
            }

        }
    }
}
