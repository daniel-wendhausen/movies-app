using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MoviesApp.Models;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;

namespace MoviesApp.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        public ICommand LoadMoviesCommand { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set { SetProperty(ref movies, value); }
        }

        private IEnumerable<Genre> Genres { get; set; }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            LoadMoviesCommand = new Command(async () => await ExecuteLoadMoviesCommand());
        }

        public async Task ExecuteLoadMoviesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var movieResponse = await MovieService.GetAsync(CurrentPage++);
                movieResponse.Results.ToList().ForEach(Movies.Add);
                TotalPages = movieResponse.TotalPages;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}