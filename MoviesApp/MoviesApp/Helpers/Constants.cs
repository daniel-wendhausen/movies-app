using System;
using System.Globalization;

namespace MoviesApp.Helpers
{
    public static class Constants
    {
        private const String API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const String BASE_URL = "https://api.themoviedb.org/3/";
        public const String IMAGE_BASE_URL = "https://image.tmdb.org/t/p/w500{0}";
        public const String APP_DATE_FORMAT = "{0:dd/MM/yyyy}";

        public static readonly String UPCOMING_MOVIES_URL = BASE_URL + "movie/upcoming?page={0}&api_key=" + API_KEY + "&language=" + LANGUAGE;
        public static readonly String GENRES_URL = BASE_URL + "genre/movie/list?api_key=" + API_KEY + "&language=" + LANGUAGE;
        private static readonly String LANGUAGE = CultureInfo.CurrentCulture.ToString();
    }
}