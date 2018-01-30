using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Enterprises;
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
                new Sector(5, "Good", EnterprisesCollection.Get()[0].Id),
                new Sector(6, "Super Lux", EnterprisesCollection.Get()[0].Id)
            };
        }
    }
}
