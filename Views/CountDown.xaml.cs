using Microsoft.Extensions.DependencyInjection;
using ShabbatMovieLauncher.ViewModels;
using System.Windows.Controls;


namespace ShabbatMovieLauncher.Views
{
    /// <summary>
    /// Interaction logic for CountDown.xaml
    /// </summary>
    public partial class CountDown : UserControl
    {
        public CountDown()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<CountDownVM>(); ;
        }
    }
}
