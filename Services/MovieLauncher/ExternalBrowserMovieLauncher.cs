using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public class ExternalBrowserMovieLauncher : IMovieLauncher
    {
        public void Launch(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "chrome.exe",
                UseShellExecute = true,
                Arguments = $"--kiosk --autoplay-policy=no-user-gesture-required --incognito \"{url}\""
            };

            Process.Start(psi);
        }
    }
}
