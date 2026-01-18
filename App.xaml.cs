using Microsoft.Extensions.DependencyInjection;
using ShabbatMovieLauncher.Services;
using ShabbatMovieLauncher.ViewModels;
using System;
using System.Windows;

namespace ShabbatMovieLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }
        public new static App Current => (App)Application.Current;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();

            // services
            services.AddSingleton<IMovieLauncher,ChromeMovieLauncher>();
            services.AddSingleton<IScheduler, Scheduler>();

            // viewmodels
            services.AddTransient<MainWindowVM>();
            services.AddTransient<ScheduleItemVM>();
            services.AddTransient<CountDownVM>();
            services.AddTransient<BrowserMovieWindowVM>();

            Services = services.BuildServiceProvider();
        }
    }
}
