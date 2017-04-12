using MoviesApp.Models;
using MoviesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesListPage : ContentPage
    {
        MovieViewModel viewModel;

        public MoviesListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MovieViewModel();
        }

        public async void BrowseMovieList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == viewModel.Movies[viewModel.Movies.Count - 1] &&
                viewModel.CurrentPage < viewModel.TotalPages)
                await viewModel.ExecuteLoadMoviesCommand();
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var movie = e.SelectedItem as Movie;
            if (movie == null)
                return;

            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailPage(movie));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Movies.Count == 0)
                viewModel.LoadMoviesCommand.Execute(null);
            
        }
    }
}
