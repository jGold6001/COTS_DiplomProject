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
        IRepository<City> Cities { get; }
        IRepository<Ticket> Tickets {get;}
        IRepository<TicketPlaceDetails> TicketPlaceDetails { get; }
        IRepository<Purchase> Purchases { get; }
        IRepository<PurchaseClientDetails> PurchaseClientDetailses { get; }
        void Save();
    }
}
