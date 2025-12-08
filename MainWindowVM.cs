using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShabbatMovieLauncher.Services;
using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ShabbatMovieLauncher
{
    public class MainWindowVM : ObservableObject
    {
        public ICommand SetScheduleButton { get; set; }

        private DateTime? _scheduledDateTime;

        public DateTime? ScheduledDateTime
        {
            get { return _scheduledDateTime; }
            set { SetProperty<DateTime?>(ref _scheduledDateTime,value); }
        }

        private string _movieUrl = "URL";

        public string MovieUrl
        {
            get { return _movieUrl; }
            set { SetProperty<string>(ref _movieUrl, value); }
        }

        private Scheduler _scheduler = new Scheduler();

        public MainWindowVM()
        {
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
                        var psi = new ProcessStartInfo
                        {
                            FileName = "chrome.exe",
                            UseShellExecute = true,
                            Arguments = $"--kiosk --autoplay-policy=no-user-gesture-required --incognito \"{url}\""
                        };

                        Process.Start(psi);

                    }, MovieUrl);
            }
            else
            {
                MessageBox.Show("Please select a valid date and time.");
            }
           
        }
    }
}
