using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Sectors
{
    public static class MpxSectorsCollections
    {
        public static List<Sector> Get()
        {
            return new List<Sector>()
            {
                new Sector(5, "Good"),
                new Sector(6, "Super Lux")
            };
        }
    }
}
