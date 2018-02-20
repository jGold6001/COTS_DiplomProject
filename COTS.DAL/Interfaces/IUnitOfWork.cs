using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        IRepository<MovieDetails> MovieDetailses { get; }

        IRepository<Seance> Seances { get; }
        IRepository<Technology> Technologies { get; }

        IRepository<Enterprise> Enterprises { get; }
        IRepository<Cinema> Cinemas { get; }
        IRepository<Hall> Halls { get; }
        IRepository<Sector> Sectors { get; }
        IRepository<Place> Places { get; }

        IRepository<Tariff> Tariffs { get; }

        IRepository<City> Cities { get; }

        IRepository<Ticket> Tickets {get;}    
        IRepository<Purchase> Purchases { get; }
        IRepository<Customer> Customers { get; }

        IRepository<User> Users { get; }
        IRepository<UserDetails> UserDetailses { get; }
        IRepository<UserRole> UserRoles { get; }
        void Save();
    }
}
