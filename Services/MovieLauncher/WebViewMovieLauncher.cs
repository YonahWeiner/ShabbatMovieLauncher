using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services.MovieLauncher
{
    public class WebViewMovieLauncher : IMovieLauncher
    {
        public void Launch(string url)
        {
            //option 1: raise event and main window handles it in its own window
            //option 2: make a new window and open it there
            
        }
    }
}
