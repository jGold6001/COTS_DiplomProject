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
        public virtual DbSet<MovieDetails> MovieDetailses { get; set; }

        public virtual DbSet<Seance> Seances { get; set; }

        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Place> Places { get; set; }

        public virtual DbSet<Tariff> Tariffs { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
      
      
    }
}
