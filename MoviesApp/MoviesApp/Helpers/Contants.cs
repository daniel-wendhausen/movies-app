using System;
using System.Globalization;

namespace MoviesApp.Helpers
{
    public static class Contants
    {
        private static readonly String BASE_URL = "https://api.themoviedb.org/3/";
        public static readonly String IMAGE_BASE_URL = "https://image.tmdb.org/t/p/w500/{0}";
        public static readonly String SEARCH_URL = BASE_URL + "search/movie?api_key={0}&query={1}";
        public static readonly String UPCOMING_MOVIES = BASE_URL + "movie/upcoming?api_key={0}&page={1}&language=" + LANGUAGE;
        public static readonly String GENRES = BASE_URL + "genre/movie/list?api_key={0}&language=" + LANGUAGE;
        public static readonly String API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        public static readonly String LANGUAGE = CultureInfo.CurrentCulture.ToString();
    }
}
