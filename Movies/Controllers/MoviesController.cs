using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public List<MovieEntity> GetAll(int? currentPage)
        {
            var pageSize = 10;
            if (currentPage == null) currentPage = 0;
            return _movieService.GetMoviesWithPagination((int)currentPage, pageSize);            
        }

        [HttpGet]
        public MovieEntity GetMovieById(int Id)
        {
            return _movieService.GetMovieById(Id);
        }

        [HttpPost]
        public void AddMovie(MovieEntity movie)
        {
            _movieService.AddMovie(movie);
        }

    }
}