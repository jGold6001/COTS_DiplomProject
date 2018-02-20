using COTS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using COTS.DAL.EF;
using System.Data.Entity;

namespace COTS.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext db;

        private MovieRepository movieRepository;
        private MovieDetailsRepository movieDetailsRepository;

        private EnterpriseRepository enterpriseRepository;
        private CinemaRepository cinemaRepository;
        private PlaceRepository placeRepository;
        private SectorRepository sectorRepository;
        private HallRepository hallRepository;

        private TariffRepository tariffRepository;

        private TechnologyRepository technologyRepository;
        private SeanceRepository seanceRepository;

        private CityRepository cityRepository;

        private TicketRepository ticketRepository;
      
        private PurchaseRepository purchaseRepository;
        private CustomerRepository customerRepository;

        private UserRepository userRepository;
        private UserDetailsRepository userDetailsRepository;
        private UserRoleRepository userRoleRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new CotsContext(connectionString);
        }
        public IRepository<Movie> Movies
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository(db);
                return movieRepository;
            }
        }

        public IRepository<MovieDetails> MovieDetailses
        {
            get
            {
                if (movieDetailsRepository == null)
                    movieDetailsRepository = new MovieDetailsRepository(db);
                return movieDetailsRepository;
            }
        }


        public IRepository<Technology> Technologies
        {
            get
            {
                if (technologyRepository == null)
                    technologyRepository = new TechnologyRepository(db);
                return technologyRepository;
            }
        }

        public IRepository<Seance> Seances
        {
            get
            {
                if (seanceRepository == null)
                    seanceRepository = new SeanceRepository(db);
                return seanceRepository;
            }
        }

        public IRepository<Enterprise> Enterprises
        {
            get
            {
                if (enterpriseRepository == null)
                    enterpriseRepository = new EnterpriseRepository(db);
                return enterpriseRepository;
            }
        }

        public IRepository<Cinema> Cinemas
        {
            get
            {
                if (cinemaRepository == null)
                    cinemaRepository = new CinemaRepository(db);
                return cinemaRepository;
            }
        }

        public IRepository<Hall> Halls
        {
            get
            {
                if (hallRepository == null)
                    hallRepository = new HallRepository(db);
                return hallRepository;
            }
        }

        public IRepository<Sector> Sectors
        {
            get
            {
                if (sectorRepository == null)
                    sectorRepository = new SectorRepository(db);
                return sectorRepository;
            }
        }

        public IRepository<Place> Places
        {
            get
            {
                if (placeRepository == null)
                    placeRepository = new PlaceRepository(db);
                return placeRepository;
            }
        }

        public IRepository<Tariff> Tariffs
        {
            get
            {
                if (tariffRepository == null)
                    tariffRepository = new TariffRepository(db);
                return tariffRepository;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }

        

        public IRepository<Purchase> Purchases
        {
            get
            {
                if (purchaseRepository == null)
                    purchaseRepository = new PurchaseRepository(db);
                return purchaseRepository;
            }
        }   

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<UserDetails> UserDetailses
        {
            get
            {
                if (userDetailsRepository == null)
                    userDetailsRepository = new UserDetailsRepository(db);
                return userDetailsRepository;
            }
        }

        public IRepository<UserRole> UserRoles
        {
            get
            {
                if (userRoleRepository == null)
                    userRoleRepository = new UserRoleRepository(db);
                return userRoleRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
