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
        public ICollection<Place> Places { get; set; }
        public Tariff()
        {
            Places = new List<Place>();
        }

    }
}
