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
        public string WeekDay { get; set; }
        public string TimePeriod { get; set; }
        public string TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public long? SectorId { get; set; }
        public Sector Sector { get; set; }
        public ICollection<Seance> Seances { get; set; }

        public Tariff()
        {
            Seances = new List<Seance>();
        }

        public Tariff(string name, decimal price, long sectorId, string weekDay, string timePeriod, string technologyId)
        {
            this.Name = name;
            this.Price = price;
            this.SectorId = sectorId;
            this.WeekDay = weekDay;
            this.TimePeriod = timePeriod;
            this.TechnologyId = technologyId;
            Seances = new List<Seance>();
        }

    }
}
