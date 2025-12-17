using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShabbatMovieLauncher.Services;
using ShabbatMovieLauncher.Services.MovieLauncher;
using ShabbatMovieLauncher.ViewModels;

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
            DataContext = new ScheduleItemVM(new ChromeMovieLauncher());
        }
    }
}
