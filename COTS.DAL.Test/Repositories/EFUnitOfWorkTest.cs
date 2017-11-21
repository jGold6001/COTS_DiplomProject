using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Repositories;
using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData;
using System.Collections.Generic;
using COTS.DAL.Test.CollectionForData.Seances;
using COTS.DAL.Test.CollectionForData.Cities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System.Diagnostics;

namespace COTS.DAL.Test.Repositories
{
    [TestClass]
    public class EFUnitOfWorkTest
    {
        private string connectionString = "name=CotsContext";
        private EFUnitOfWork unitOfwork;

        //data
        private List<Movie> movies = MoviesCollection.Get();
        private List<Seance> seancesFlorence = FlorenceSeancesCollection.Get();
        private List<Seance> seancesMultProspect = MultiplexProspectSeancesCollection.Get();
        private List<Seance> seancesMultSkyMall = MultiplexSkyMallSeancesCollection.Get();
        private List<Cinema> cinemas = CinemasCollection.Get();
        private List<City> cities = CitiesCollection.Get();

        //repositories
        private MovieRepository movieRepo;
        private SeanceRepository seanceRepo;
        private CinemaRepository cinemaRepo;
        private CityRepository cityRepo;


        [TestInitialize]
        public void Init()
        {
            unitOfwork = new EFUnitOfWork(connectionString);
            movieRepo = unitOfwork.Movies as MovieRepository;
            seanceRepo = unitOfwork.Seances as SeanceRepository;
            cinemaRepo = unitOfwork.Cinemas as CinemaRepository;
            cityRepo = unitOfwork.Cities as CityRepository;
        }

        [TestMethod]
        public void TestAddOrUpdate()
        {
            City cityKiev = cities[0];
            City cityHarkov = cities[1];

            Movie bladeRunner = movies[0];
            Movie pony =  movies[1];
            Movie salut = movies[2];

            Cinema mSkymall = cinemas[0];
            Cinema mProspect = cinemas[1];
            Cinema florence = cinemas[3];

            cityRepo.AddOrUpdate(cityKiev);
            foreach (var item in cinemas)
            {
                if (item.Name.Contains("Dafi"))
                    item.City = cityHarkov;
                else
                    item.City = cityKiev;

                cinemaRepo.AddOrUpdate(item);
            }    

            foreach (var item in movies)
                movieRepo.AddOrUpdate(item);

            for (int i = 0; i < seancesFlorence.Count; i++)
            {
                if (i < 3)
                    seancesFlorence[i].Movie = bladeRunner; 
                else if (i >= 3 && i < 5)
                    seancesFlorence[i].Movie = pony;
                else
                    seancesFlorence[i].Movie = salut;

                seancesFlorence[i].Cinema = florence;
                seanceRepo.AddOrUpdate(seancesFlorence[i]);
            }

            for (int i = 0; i < seancesMultProspect.Count; i++)
            {
                if (i < 5)
                    seancesMultProspect[i].Movie = bladeRunner;
                else if (i >= 5 && i < 9)
                    seancesMultProspect[i].Movie = pony;
                else
                    seancesMultProspect[i].Movie = salut;

                seancesMultProspect[i].Cinema = mProspect;
                seanceRepo.AddOrUpdate(seancesMultProspect[i]);
            }

            for (int i = 0; i < seancesMultSkyMall.Count; i++)
            {
                if (i < 3)
                    seancesMultSkyMall[i].Movie = bladeRunner;
                else if (i >= 3 && i < 5)
                    seancesMultSkyMall[i].Movie = pony;
                else
                    seancesMultSkyMall[i].Movie = salut;

                seancesMultSkyMall[i].Cinema = mSkymall;
                seanceRepo.AddOrUpdate(seancesMultSkyMall[i]);
            }

            unitOfwork.Save();
        }

        [TestMethod]
        public void TestFindMoviesPremeries()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllPremeries() as List<Movie>;            
            Assert.AreEqual(movies[2].Name, moviesPremeries[0].Name);
        }

        [TestMethod]
        public void TestFindMoviesComingSoon()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllComingSoon() as List<Movie>;
            Assert.AreEqual(movies[1].Name, moviesPremeries[0].Name);
        }

        [TestMethod]
        public void TestGetMoviesTop10ByRankOrder()
        {
            List<Movie> moviesPremeries = movieRepo.GetTop10ByRankOrder() as List<Movie>;
            foreach (var item in moviesPremeries)
                Trace.WriteLine(item.RankSales);
        }

        [TestMethod]
        public void TestFindCinemasByCity()
        {
            List<Cinema> cinemasByCity = cinemaRepo.FindAllByCity("Харьков") as List<Cinema>;          
            Assert.AreEqual(cinemas[2].Name, cinemasByCity[0].Name);
        }

        [TestMethod]
        public void TestFindSeancesByDate()
        {
            List<Seance> seancesByDate = seanceRepo.FindByDate(DateTime.Now.Date)as List<Seance>;
            foreach (var item in seancesByDate)
              Trace.WriteLine(item.DateAndTime);
        }

        [TestMethod]
        public void TestFindSeancesByMovie()
        {
            List<Seance> seancesByMovie = seanceRepo.FindByMovie(movies[0].Name) as List<Seance>;
            foreach (var item in seancesByMovie)
                Trace.WriteLine(item.MovieId);
        }

        [TestMethod]
        public void TestFindSeancesByCinema()
        {
            List<Seance> seancesByCinema = seanceRepo.FindByCinema(cinemas[0].Name) as List<Seance>;
            foreach (var item in seancesByCinema)
                Trace.WriteLine(item.CinemaId);
        }

        [TestMethod]
        public void TestDelete()
        {
            foreach (var item in movieRepo.GetAll())
                movieRepo.Delete(item);

            foreach (var item in cityRepo.GetAll())
                cityRepo.Delete(item);

            foreach (var item in cinemaRepo.GetAll())
                cinemaRepo.Delete(item);

            foreach (var item in seanceRepo.GetAll())
                seanceRepo.Delete(item);

            unitOfwork.Save();
        }
    }
}
