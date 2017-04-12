using MoviesApp.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoviesApp.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "backdrop_path")]
        private string BackdropPath { get; set; }
        [JsonProperty(PropertyName = "genre_ids")]
        public ICollection<int> Genre { get; set; }
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        public string Genres { get; set; }
        [JsonIgnore]
        public string BackdropImageURL
        {
            get
            {
                return String.Format(Constants.IMAGE_BASE_URL, this.BackdropPath);
            }
        }
        
        [JsonIgnore]
        public string FormattedReleaseDate
        {
            get
            {
                return String.Format(Constants.APP_DATE_FORMAT, this.ReleaseDate);
            }
        }
    }

    public class MovieResponse
    {
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty(PropertyName = "results")]
        public ObservableCollection<Movie> Results { get; set; }
    }

    public class Genre
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class GenreResponse
    {
        [JsonProperty(PropertyName = "genres")]
        public ICollection<Genre> Genres { get; set; }
    }
}
