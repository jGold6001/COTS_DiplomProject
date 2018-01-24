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
        public City City { get; set; }
        public string CityId { get; set; }
        public ICollection<Hall> Halls { get; set; }
        public Cinema()
        {
            Halls = new List<Hall>();
        }

        public Cinema(string id, string name, string address, string imagePath)
        {
            Id = id;
            Name = name;
            Address = address;
            ImagePath = imagePath;
            Halls = new List<Hall>();
        }
    }
}
