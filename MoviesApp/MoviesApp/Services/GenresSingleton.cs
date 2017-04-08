using MoviesApp.Helpers;
using MoviesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesApp.Services
{
    public sealed class GenresSingleton
    {
        private static readonly GenresSingleton _instance = new GenresSingleton();
        private Task<IDictionary<int, string>> _genresLookupTask;

        public static GenresSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        private GenresSingleton()
        {
            _genresLookupTask = Task.Run(() => GenresSingleton.Instance.GetGenresAsync());
        }

        public IDictionary<int, string> GenresLookup
        {
            get
            {
                return _genresLookupTask.Result;
            }
        }
        public static IDictionary<int, string> GenreLookup { get; set; }


        public async Task<IDictionary<int, string>> GetGenresAsync()
        {
            using (var client = new HttpClient())
            {
                var genre_url = new Uri(string.Format(Constants.GENRES_URL));
                var response = await client.GetAsync(genre_url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var genreResponse = JsonConvert.DeserializeObject<GenreResponse>(content);
                    return genreResponse.Genres.ToDictionary(key => key.Id, value => value.Name);
                }
                return null;
            }
        }
    }
}
