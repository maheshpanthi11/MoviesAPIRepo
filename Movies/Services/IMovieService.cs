using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IMovieService
    {
        List<MovieEntity> GetMoviesWithPagination(int currentPage, int pageSize);
        MovieEntity GetMovieById(int id);
        Task AddMovie(MovieEntity movie);

    }
}
