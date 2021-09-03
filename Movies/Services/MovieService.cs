using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        public static IList<MovieEntity> Movies { get; set; }

        public MovieService()
        {
            Movies = new List<MovieEntity>()
            {
            new MovieEntity { Id = 1, Title = "Toy Story 1", Director = "John Lasseter" },
            new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" },
            new MovieEntity { Id = 3, Title = "Arrival", Director = "Denis Villeneuve" },
            new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" },
            new MovieEntity { Id = 5, Title = "The Martian", Director = "Ridley Scott" },
             new MovieEntity { Id = 6, Title = "Avatar", Director = "James Cameron" },
            new MovieEntity { Id = 7, Title = "Prometheus", Director = "Ridley Scott" },
            new MovieEntity { Id = 8, Title = "Sunshine", Director = "Danny Boyle" },
             new MovieEntity { Id = 9, Title = "Serenity", Director = "Joss Whedon" },
            new MovieEntity { Id = 10, Title = "WALL-E", Director = "Andrew Stanton" }};
        }

        public void AddMovie(MovieEntity movie)
        {
            Movies.Add(movie);
        }

        public MovieEntity GetMovieById(int id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }

        public List<MovieEntity> GetMoviesWithPagination(int currentPage, int pageSize)
        {
            return Movies.Skip(pageSize * (int)currentPage).Take(pageSize).ToList();
        }
    }
}
