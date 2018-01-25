using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Hall
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Place> Places { get; set; }

        public Hall()
        {
            Places = new List<Place>();
        }

        public Hall(long id, string name, string cinemaId)
        {
            this.Id = id;
            this.Name = name;
            this.CinemaId = cinemaId;
            Places = new List<Place>();
        }
    }
}
