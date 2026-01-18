using Microsoft.Extensions.DependencyInjection;
using ShabbatMovieLauncher.ViewModels;
using System.Windows.Controls;

namespace ShabbatMovieLauncher.Views
{
    /// <summary>
    /// Interaction logic for ScheduleItem.xaml
    /// </summary>
    public partial class ScheduleItem : UserControl
    {
        public ScheduleItem()
        {
            InitializeComponent();
            // Todo: resolve movie launcher to configuration in app.xaml.cs 
            DataContext = App.Current.Services.GetRequiredService<ScheduleItemVM>();
        }
    }
}
