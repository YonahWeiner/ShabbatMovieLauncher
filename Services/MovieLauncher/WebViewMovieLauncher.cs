using MahApps.Metro.Controls;
using ShabbatMovieLauncher.ViewModels;
using ShabbatMovieLauncher.Views;
using System;

namespace ShabbatMovieLauncher.Services.MovieLauncher
{
    public class WebViewMovieLauncher : IMovieLauncher
    {
        public void Launch(string url)
        {
            //option 1: raise event and main window handles it in its own window
            //option 2: make a new window and open it there
           
            App.Current.Invoke(() =>
                {
                    BrowserMovieWindow browserWindow = new BrowserMovieWindow() { DataContext = new BrowserMovieWindowVM()
                    {
                        MovieUrl = new Uri(url)
                    } };
                    browserWindow.Owner = App.Current.MainWindow;
                    //browserWindow.Topmost = true; // consider to keep. it keeps window over all other apps.
                                                  // seems good for shabbat, but quite annoying in general
                    browserWindow.Show();
                    browserWindow.Activate(); // force focus
                });

        }
    }
    
}
