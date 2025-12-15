using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
        
        private Visibility _scheduleItemVisibility;

        public Visibility ScheduleItemVisibility
        {
            get { return _scheduleItemVisibility; }
            set { SetProperty<Visibility>(ref _scheduleItemVisibility, value); }
        }

        private Visibility _countDownVisibility;
        public Visibility CountDownVisibility
        {
            get { return _countDownVisibility; }
            set { SetProperty<Visibility>(ref _countDownVisibility, value); }
        }

        public MainWindowVM()
        {
            ScheduleItemVisibility = Visibility.Visible;
            CountDownVisibility = Visibility.Collapsed;

            // Navigate to CountDown view on ScheduleClicked message
            WeakReferenceMessenger.Default.Register<ScheduleClicked>(this, (sender, args) =>
            {
                CountDownVisibility = Visibility.Visible;
                ScheduleItemVisibility = Visibility.Collapsed;
            });

            // Navigate to ScheduleItem view on EditClicked message
            WeakReferenceMessenger.Default.Register<EditClicked>(this, (sender, args) =>
            {
                CountDownVisibility = Visibility.Collapsed;
                ScheduleItemVisibility = Visibility.Visible;
            });
        }
    }
}
