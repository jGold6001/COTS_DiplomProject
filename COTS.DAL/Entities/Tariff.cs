using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Tariff
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public long? SectorId { get; set; }
        public Sector Sector { get; set; }
        public ICollection<Seance> Seances { get; set; }

        public Tariff()
        {
            Seances = new List<Seance>();
        }

        public Tariff(string name, decimal price, long sectorId)
        {
            this.Name = name;
            this.Price = price;
            this.SectorId = sectorId;
            Seances = new List<Seance>();
        }

    }
}
