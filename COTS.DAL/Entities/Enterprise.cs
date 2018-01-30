using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Enterprise
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cinema> Cinemas { get; set; }
        public ICollection<Sector> Sectors { get; set; }

        public Enterprise(string id, string Name)
        {
            this.Id = id;
            this.Name = Name;
            Cinemas = new List<Cinema>();
            Sectors = new List<Sector>();
        }
        public Enterprise()
        {
            Cinemas = new List<Cinema>();
            Sectors = new List<Sector>();
        }
    }
}
