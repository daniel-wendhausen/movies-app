using MoviesApp.Services;
using MoviesApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesApp
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();
            var a = GenresSingleton.Instance;
            MainPage = new NavigationPage(new MoviePage());
        }
	}
}
