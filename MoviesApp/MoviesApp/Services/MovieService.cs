using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MoviesApp.Helpers;
using MoviesApp.Models;
using System.Net.Http;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(MoviesApp.Services.MovieService))]
namespace MoviesApp.Services
{
    class MovieService : IMovieService
    {
        HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }


        public async Task<MovieResponse> GetAsync(int page)
        {
            var movie_url = new Uri(string.Format(Contants.UPCOMING_MOVIES, Contants.API_KEY, page));
            var response = await client.GetAsync(movie_url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(content);

            var genreLookup = GenresSingleton.Instance.GenresLookup;

            foreach (var movie in movieResponse.Results)
            {
                movie.Genres = string.Join(", ", genreLookup.Where(x => movie.Genre.Contains(x.Key)).Select(x => x.Value).ToList());
            }
            return movieResponse;
        }
    }
}
