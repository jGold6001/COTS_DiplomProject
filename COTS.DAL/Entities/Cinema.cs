using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Cinema
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public Cinema()
        {
            Seances = new List<Seance>();
        }

        public Cinema(string name, string address)
        {
            Name = name;
            Address = address;
            Seances = new List<Seance>();
        }
    }
}
