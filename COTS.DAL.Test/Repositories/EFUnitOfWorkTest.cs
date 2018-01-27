using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Repositories;
using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData;
using System.Collections.Generic;
using COTS.DAL.Test.CollectionForData.Seances;
using COTS.DAL.Test.CollectionForData.Cities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using COTS.DAL.Test.CollectionForData.Halls;
using COTS.DAL.Test.CollectionForData.Places.Florence;
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
        private List<Hall> hallsMpxSkyMall = MpxSkyMallHallsCollection.Get();
        private List<Hall> hallsMpxProspect = MpxProspectHallsCollection.Get();
        private List<Hall> hallsMpxDafi = MpxDafiHallsCollection.Get();
        private List<Hall> hallsFlorence = FlorenceHallsCollection.Get();
        private List<Place> placesFlorence = FlorenceBluePlacesCollection.Get();


        //repositories
        private MovieRepository movieRepo;
        private MovieDetailsRepository movieDetailsRepo;
        private SeanceRepository seanceRepo;
        private CinemaRepository cinemaRepo;
        private CityRepository cityRepo;
        private TicketRepository ticketRepo;
        private PlaceRepository placeRepository;
        private PurchaseRepository purchaseRepo;
        private CustomerRepository customerRepository;
        private HallRepository hallRepository;
        private TariffRepository tariffRepository;


        [TestInitialize]
        public void Init()
        {
            unitOfwork = new EFUnitOfWork(connectionString);

            movieRepo = unitOfwork.Movies as MovieRepository;
            movieDetailsRepo = unitOfwork.MovieDetailses as MovieDetailsRepository;

            seanceRepo = unitOfwork.Seances as SeanceRepository;

            cinemaRepo = unitOfwork.Cinemas as CinemaRepository;
            placeRepository = unitOfwork.Places as PlaceRepository;
            hallRepository = unitOfwork.Halls as HallRepository;

            cityRepo = unitOfwork.Cities as CityRepository;

            ticketRepo = unitOfwork.Tickets as TicketRepository;         
            purchaseRepo = unitOfwork.Purchases as PurchaseRepository;
            customerRepository = unitOfwork.Customers as CustomerRepository;

            tariffRepository = unitOfwork.Tariffs as TariffRepository;
        }

        [TestMethod]
        public void PlacesTest()
        {
            foreach (var item in placesFlorence)
            {
                Trace.WriteLine($"id: {item.Id}, row: {item.Row}, number: {item.Number} ");
            }
        }

        [TestMethod()]
        public void AddDataTest()
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

            var halls = new List<Hall>();
            halls.AddRange(hallsFlorence);
            halls.AddRange(hallsMpxDafi);
            halls.AddRange(hallsMpxProspect);
            halls.AddRange(hallsMpxSkyMall);

            foreach (var item in placesFlorence)
            {                
                placeRepository.AddOrUpdate(item);
            }

            foreach (var item in halls)
            {               
                hallRepository.AddOrUpdate(item);           
            }

           

            foreach (var item in movies)
            {
                movieRepo.AddOrUpdate(item);
                movieDetailsRepo.AddOrUpdate(item.MovieDetails);
            }                        

            for (int i = 0; i < seancesFlorence.Count; i++)
            {
                if (i < 3)
                    seancesFlorence[i].Movie = bladeRunner; 
                else if (i >= 3 && i < 5)
                    seancesFlorence[i].Movie = pony;
                else
                    seancesFlorence[i].Movie = salut;
                
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

                seanceRepo.AddOrUpdate(seancesMultDafi[i]);
            }
            
           
            unitOfwork.Save();
        }

       

        public Seance GetSeanceForTickets()
        {
            foreach (var item in seanceRepo.GetAll())
            {
                if (item.HallId == FlorenceHallsCollection.Get()[0].Id
                    && item.DateAndTime.Date == DateTime.Now.Date
                )
                {
                    return item;
                }

            }
            return seanceRepo.GetAll().FirstOrDefault();
        }

        public List<Place> GetPlaces()
        {
            var place_1 = placeRepository.Get(placesFlorence[0].Id);
            var place_2 = placeRepository.Get(placesFlorence[19].Id);
            place_1.IsBusy = true;
            place_2.IsBusy = true;
            placeRepository.AddOrUpdate(place_1);
            placeRepository.AddOrUpdate(place_2);
            unitOfwork.Save();

            return new List<Place>(){
                placeRepository.Get(placesFlorence[0].Id),
                placeRepository.Get(placesFlorence[19].Id)
            };
        }

        [TestMethod]
        public void AddPurchaseTest()
        {
            var purchase = new Purchase()
            {
                Id = "test231243"
            };
            purchaseRepo.AddOrUpdate(purchase);

            var customer = new Customer()
            {
                Id = purchase.Id,
                Email = "test@milo.net",
                FullName = "Testov Test",
                Phone = 30665554433
            };
            customerRepository.AddOrUpdate(customer);
            unitOfwork.Save();


            var seance = this.GetSeanceForTickets();
            var places = this.GetPlaces();

            var ticket_1 = new Ticket()
            {
                Id = "test001",
                SeanceId = seance.Id,
                PurchaseId = purchase.Id,
                PlaceId = places[0].Id,
                State = 2

            };
            ticketRepo.AddOrUpdate(ticket_1);

            var ticket_2 = new Ticket()
            {
                Id = "test002",
                SeanceId = seance.Id,
                PurchaseId = purchase.Id,
                PlaceId = places[1].Id,
                State = 2

            };
            ticketRepo.AddOrUpdate(ticket_2);
            unitOfwork.Save();
        }

        [TestMethod]
        public void FindMoviesPremeriesTest()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllPremeries() as List<Movie>;            
            Assert.AreEqual(movies[2].Name, moviesPremeries[0].Name);
        }

        [TestMethod]
        public void GetAllPlacesByCityCinemaAndHallTest()
        {
            List<Place> places = placeRepository.GetAllByCityCinemaAndHall("kiev", "florence", "Синий") as List<Place>;
            foreach (var item in places)
            {
                Trace.WriteLine($"Place id: {item.Id} - row: {item.Row} - num: {item.Number}");
            }

        }

        [TestMethod]
        public void FindMoviesComingSoonTest()
        {
            List<Movie> moviesPremeries = movieRepo.FindAllComingSoon() as List<Movie>;
            foreach (var item in moviesPremeries)
                Trace.WriteLine($"name - {item.Name}");
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
            foreach (var item in moviesByCity)
            {
                Trace.WriteLine(item.Name);
            }
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
        public void FindAllByCinemaMovieAndDateTest()
        {
            long movieId = movieRepo.GetAll().Select(m => m.Id).FirstOrDefault();
            string cinemaId = cinemas[0].Id;
            DateTime date = DateTime.Now.Date;
            IEnumerable<Seance> seances = seanceRepo.FindAllByCinemaMovieAndDate(cinemaId, movieId, date);
            foreach (var item in seances)
                Trace.WriteLine($"Hall: {item.HallId} Movie: {item.MovieId} and Date: {item.DateAndTime}");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            foreach (var item in movieRepo.GetAll())
                movieRepo.Delete(item);

            foreach (var item in movieDetailsRepo.GetAll())
                movieDetailsRepo.Delete(item);

            foreach (var item in cityRepo.GetAll())
                cityRepo.Delete(item);

            foreach (var item in hallRepository.GetAll())
                hallRepository.Delete(item);

            foreach (var item in cinemaRepo.GetAll())
                cinemaRepo.Delete(item);

            foreach (var item in seanceRepo.GetAll())
                seanceRepo.Delete(item);

            foreach (var item in ticketRepo.GetAll())
                ticketRepo.Delete(item);

            foreach (var item in placeRepository.GetAll())
                placeRepository.Delete(item);

            foreach (var item in purchaseRepo.GetAll())
                purchaseRepo.Delete(item);

            foreach (var item in customerRepository.GetAll())
                customerRepository.Delete(item);

            unitOfwork.Save();
        }

       
    }
}
