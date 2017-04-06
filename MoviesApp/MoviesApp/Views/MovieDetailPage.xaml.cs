using MoviesApp.Models;
using MoviesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();

            BindingContext = new MovieDetailViewModel(movie);
        }
    }
}
