using CommunityToolkit.Mvvm.ComponentModel;
using System;


namespace ShabbatMovieLauncher.ViewModels
{
    public class BrowserMovieWindowVM : ObservableObject
    {
        private Uri _movieUrl;
        public Uri MovieUrl
        {
            get { return _movieUrl; }
            set { SetProperty<Uri>(ref _movieUrl, value); }
        }

        public BrowserMovieWindowVM()
        {
            
        }
    }
}
