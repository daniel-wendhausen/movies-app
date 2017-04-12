using MoviesApp.Models;

namespace MoviesApp.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { SetProperty(ref movie, value); }
        }

        public MovieDetailViewModel(Movie movie)
        {
            this.Movie = movie;
        }
    }
}