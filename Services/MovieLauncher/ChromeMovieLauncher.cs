using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public class ChromeMovieLauncher : IMovieLauncher
    {
        public void Launch(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "chrome.exe",
                UseShellExecute = true,
                // this seems to autoplay for me. although may be unpredictable. best to prompt user to
                // turn on autoplay for specific url in chrome browser
                Arguments = $"--kiosk --autoplay-policy=no-user-gesture-required --incognito \"{url}\""
            };

            Process.Start(psi);

            // Minimize main app so it doesn't block chrome browser. unpredictable behavior, but works for me
            System.Threading.Thread.Sleep(1000);
            App.Current.Dispatcher.Invoke(() => App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized);
        }
    }
}
