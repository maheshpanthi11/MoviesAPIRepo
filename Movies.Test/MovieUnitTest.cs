using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Controllers;
using Movies.Models;
using Movies.Services;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Test
{
    [TestClass]
    public class MovieUnitTest
    {
        private Mock<IMovieService> movieService;
        private int movieId = 2;
        private int currentPage = 0;
        private int pageSize = 10;

        public MovieUnitTest()
        {
            movieService = new Mock<IMovieService>();
            movieService.Setup(a => a.GetMovieById(movieId)).Returns(new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" });
            movieService.Setup(a => a.GetMoviesWithPagination(currentPage, pageSize)).Returns(new List<MovieEntity>() { new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" } });
        }

        [TestMethod]
        public void GetMoviesWithDefaultCurrentPage()
        {
            int? currentPage = null;
            var controller = new MoviesController(movieService.Object);
            var result = controller.Get(currentPage);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMovieByIdTest()
        {
            var controller = new MoviesController(movieService.Object);
            var movie = controller.GetMovieById(movieId);
            Assert.AreEqual(movie.Id, movieId);
        }
    }
}
