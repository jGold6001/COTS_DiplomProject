using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Sectors
{
    public static class FlorenceSectorsCollection
    {
        public static List<Sector> Get()
        {
            return new List<Sector>()
            {
                new Sector(1, "Green"),
                new Sector(2, "Red"),
                new Sector(3, "Cyan"),
                new Sector(4, "Blue")
            };
        }
    }
}
