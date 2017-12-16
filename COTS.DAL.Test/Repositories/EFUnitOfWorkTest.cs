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
using System.Linq;

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
        private List<Seance> seancesMultDafi = MultiplexDafiSeancesCollection.Get();
        private List<Cinema> cinemas = CinemasCollection.Get();
        private List<City> cities = CitiesCollection.Get();

        //repositories
        private MovieRepository movieRepo;
        private SeanceRepository seanceRepo;
        private CinemaRepository cinemaRepo;
        private CityRepository cityRepo;
        private TicketRepository ticketRepo;
        private PurchaseRepository purchaseRepo;


        [TestInitialize]
        public void Init()
        {
            unitOfwork = new EFUnitOfWork(connectionString);
            movieRepo = unitOfwork.Movies as MovieRepository;
            seanceRepo = unitOfwork.Seances as SeanceRepository;
            cinemaRepo = unitOfwork.Cinemas as CinemaRepository;
            cityRepo = unitOfwork.Cities as CityRepository;
            ticketRepo = unitOfwork.Tickets as TicketRepository;
            purchaseRepo = unitOfwork.Purchases as PurchaseRepository;
        }

        [TestMethod]
        public void AddOrUpdateTest()
        {
            City cityKiev = cities[0];
            City cityHarkov = cities[1];

            Movie bladeRunner = movies[0];
            Movie pony =  movies[1];
            Movie salut = movies[2];
            Movie comatose = movies[3];

            Cinema mSkymall = cinemas[0];
            Cinema mProspect = cinemas[1];
            Cinema mDafi = cinemas[2];
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

            for (int i = 0; i < seancesMultDafi.Count; i++)
            {
                if (i < 3)
                    seancesMultDafi[i].Movie = bladeRunner;
                else if (i >= 3 && i < 5)
                    seancesMultDafi[i].Movie = pony;
                else
                    seancesMultDafi[i].Movie = comatose;

                seancesMultDafi[i].Cinema = mDafi;
                seanceRepo.AddOrUpdate(seancesMultDafi[i]);
            }

            unitOfwork.Save();
        }
     

        [TestMethod()]
        public void AddOrUpdatePurchaseAndTicketsTest()
        {
            var purchase = new Purchase()
            {
                Id = "as231243"
            };
            purchaseRepo.AddOrUpdate(purchase);
            unitOfwork.Save();

            var seance = seanceRepo.GetAll().FirstOrDefault();
            var ticket_1 = new Ticket()
            {
                Id = "001",
                Seance = seance,
                Hall = "1",
                Place = 1,
                Row = 1,
                Price = 100,
                Tariff = "simple",
                Purchase = purchase
            };

            var ticket_2 = new Ticket()
            {
                Id = "002",
                Seance = seance,
                Hall = "1",
                Place = 1,
                Row = 2,
                Price = 200,
                Tariff = "vip",
                Purchase = purchase
            };

            ticketRepo.AddOrUpdate(ticket_1);
            ticketRepo.AddOrUpdate(ticket_1);
            unitOfwork.Save();

            foreach (var item in ticketRepo.GetAll())
                ticketRepo.Delete(item);


            foreach (var item in purchaseRepo.GetAll())
                purchaseRepo.Delete(item);

            unitOfwork.Save();
        }

        [TestMethod]
        public void FindMoviesPremeriesTest()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllPremeries() as List<Movie>;            
            Assert.AreEqual(movies[2].Name, moviesPremeries[0].Name);
        }

        [TestMethod]
        public void FindMoviesComingSoonTest()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllComingSoon() as List<Movie>;
            foreach (var item in moviesPremeries)
                Trace.WriteLine(item.Name);
        }

        [TestMethod]
        public void GetMoviesTop10ByRankOrderTest()
        {
            List<Movie> moviesTop10 = movieRepo.GetTop10ByRankOrder() as List<Movie>;
            foreach (var item in moviesTop10)
                Trace.WriteLine(item.RankSales);
        }

        [TestMethod]
        public void FindMoviesByCityTest()
        {
            List<Movie> moviesByCity = movieRepo.FindAllByCity("harkov") as List<Movie>;           
        }

        [TestMethod]
        public void FindMoviesPremeriesByCityTest()
        {
            List<Movie> moviesByCity = movieRepo.FindAllPremeriesByCity("harkov") as List<Movie>;          
        }

        [TestMethod]
        public void FindAllComingSoonByCityTest()
        {
            List<Movie> moviesByCity = movieRepo.FindAllComingSoonByCity("kiev") as List<Movie>;
        }

        [TestMethod]
        public void GetTop10ByRankOrderTest()
        {
            List<Movie> moviesTop10 = movieRepo.GetTop10ByRankOrderByCity("kiev") as List<Movie>;
            foreach (var item in moviesTop10)
                Trace.WriteLine(item.RankSales);
        }


       [TestMethod]
        public void FindSeancesByDateTest()
        {
            List<Seance> seancesByDate = seanceRepo.FindByDate(DateTime.Now.Date)as List<Seance>;
            foreach (var item in seancesByDate)
              Trace.WriteLine(item.DateAndTime);
        }


        [TestMethod]
        public void FindSeancesByCinemaTest()
        {
            List<Seance> seancesByCinema = seanceRepo.FindAllByCinema(cinemas[0].Id) as List<Seance>;
            foreach (var item in seancesByCinema)
                Trace.WriteLine(item.CinemaId);
        }

        [TestMethod]
        public void FindSeancesByCinemaAndDateTest()
        {
            IEnumerable<Seance> seancesByCinema = seanceRepo.FindAllByCinemaAndDate(cinemas[0].Id, seancesFlorence[1].DateAndTime.Date);
            foreach (var item in seancesByCinema)
                Trace.WriteLine(item.CinemaId + " "+ item.DateAndTime);
        }

        [TestMethod]
        public void FindSeancesByMovieAndDateTest()
        {
            long movieId = movieRepo.GetAll().Select(m => m.Id).FirstOrDefault();
            IEnumerable<Seance> seancesByMovies = seanceRepo.FindAllByMovieAndDate(movieId, DateTime.Now.Date);
            foreach (var item in seancesByMovies)
                Trace.WriteLine($"Movie: {item.MovieId} and Date: {item.DateAndTime}");
        }

        [TestMethod]
        public void FindAllByCinemaMovieAndDateTest()
        {
            long movieId = movieRepo.GetAll().Select(m => m.Id).FirstOrDefault();
            string cinemaId = cinemas[0].Id;
            DateTime date = DateTime.Now.Date;
            IEnumerable<Seance> seances = seanceRepo.FindAllByCinemaMovieAndDate(cinemaId, movieId, date);
            foreach (var item in seances)
                Trace.WriteLine($"Cinema: {item.CinemaId} Movie: {item.MovieId} and Date: {item.DateAndTime}");
        }

        [TestMethod]
        public void DeleteTest()
        {
            foreach (var item in movieRepo.GetAll())
                movieRepo.Delete(item);

            foreach (var item in cityRepo.GetAll())
                cityRepo.Delete(item);

            foreach (var item in cinemaRepo.GetAll())
                cinemaRepo.Delete(item);

            foreach (var item in seanceRepo.GetAll())
                seanceRepo.Delete(item);

            foreach (var item in ticketRepo.GetAll())
                ticketRepo.Delete(item);

            unitOfwork.Save();
        }

       
    }
}
