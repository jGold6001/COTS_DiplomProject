using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Enterprises;
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
                new Sector(1, "Green",EnterprisesCollection.Get()[1].Id),
                new Sector(2, "Red", EnterprisesCollection.Get()[1].Id),
                new Sector(3, "Cyan", EnterprisesCollection.Get()[1].Id),
                new Sector(4, "Blue", EnterprisesCollection.Get()[1].Id)
            };
        }
    }
}
