using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShabbatMovieLauncher.Services;
using System;
using System.Windows;
using System.Windows.Input;


namespace ShabbatMovieLauncher
{
    public class MainWindowVM : ObservableObject
    {
        public ICommand SetScheduleButton { get; set; }
        private PCWaker pCWaker = new PCWaker();
        public MainWindowVM()
        {
           SetScheduleButton = new RelayCommand(ExecuteSetScheduleButton);
        }

        private void ExecuteSetScheduleButton()
        {
            MessageBox.Show($"PC will wake up at {pCWaker.WakeupSchedule}");
        }
    }
}
