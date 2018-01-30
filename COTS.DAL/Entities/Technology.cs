using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Technology
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }

        public Technology()
        {
            Seances = new List<Seance>();
            Tariffs = new List<Tariff>();
        }

        public Technology(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            Seances = new List<Seance>();
            Tariffs = new List<Tariff>();
        }
    }
}
