using MoviesApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoviesApp.Services
{
    public interface IMovieService
    {
        Task<MovieResponse> GetAsync(int page = 1);
    }
}
