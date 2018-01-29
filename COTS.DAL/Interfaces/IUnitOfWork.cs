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

        IRepository<Cinema> Cinemas { get; }
        IRepository<Hall> Halls { get; }
        IRepository<Sector> Sectors { get; }
        IRepository<Place> Places { get; }

        IRepository<Tariff> Tariffs { get; }

        IRepository<City> Cities { get; }

        IRepository<Ticket> Tickets {get;}    
        IRepository<Purchase> Purchases { get; }
        IRepository<Customer> Customers { get; }
        void Save();
    }
}
