using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Cinema
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public City City { get; set; }
        public string CityId { get; set; }
        public Cinema()
        {
            Seances = new List<Seance>();
        }

        public Cinema(string id, string name, string address, string imagePath)
        {
            Id = id;
            Name = name;
            Address = address;
            ImagePath = imagePath;
            Seances = new List<Seance>();
        }
    }
}
