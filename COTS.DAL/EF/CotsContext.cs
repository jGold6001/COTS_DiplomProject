using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.EF
{
    public class CotsContext : DbContext
    {
        public CotsContext(string connectionString): base(connectionString)
        {
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseClientDetails> PurchaseClientDetailses { get; set; }
        public virtual DbSet<TicketPlaceDetails> TicketPlaceDetailses { get; set; }
    }
}
