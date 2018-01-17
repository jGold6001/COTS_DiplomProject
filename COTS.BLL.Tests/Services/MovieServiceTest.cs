using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Services;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using System.Diagnostics;
using System.Linq;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class MovieServiceTest
    {
        IUnitOfWork unitOfWork;
        IMovieService movieService;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            movieService = new MovieService(unitOfWork);
        }

        [TestMethod()]
        public void GetMoviesTop10ByCityTest()
        {
            var movies = movieService.GetTop10ByRankOrderByCity("kiev");
            foreach (var item in movies)
                Trace.WriteLine($"name - {item.Name}, genre - {item.MovieDetailsDTO.Genre}");
        }

        [TestMethod()]
        public void FindAllMoviesComingSoonByCityTest()
        {
            var movies = movieService.FindAllComingSoonByCity("kiev");
            foreach (var item in movies)
                Trace.WriteLine($"name - {item.Name}, genre - {item.MovieDetailsDTO.Genre}");
        }

        [TestMethod()]
        public void FindAllMoviesPremeriesByCityTest()
        {
            var movies = movieService.FindAllPremeriesByCity("kiev");
            foreach (var item in movies)
                Trace.WriteLine($"name - {item.Name}, genre - {item.MovieDetailsDTO.Genre}");
        }

        [TestMethod()]
        public void GetMoviesOneTest()
        {
            var movieID = movieService.GetAll().FirstOrDefault().Id;
            var movie = movieService.GetOne(movieID);
            Trace.WriteLine($"name - {movie.Name}, genre - {movie.MovieDetailsDTO.Genre}");
        }
    }
}