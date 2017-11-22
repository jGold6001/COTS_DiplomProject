using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cinema> Cinemas { get; set; }
        public City()
        {
            Cinemas = new List<Cinema>();
        }

        public City(string id, string name)
        {
            Id = id;
            Name = name;
            Cinemas = new List<Cinema>();
        }
    }
}
