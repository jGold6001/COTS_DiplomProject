using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Halls
{
    public static class MpxSkyMallHallsCollection
    {
        public static List<Hall> Get()
        {
            return new List<Hall>()
            {
                new Hall(13, "1", CinemasCollection.Get()[0].Id),
                new Hall(14, "2", CinemasCollection.Get()[0].Id),
                new Hall(15, "3", CinemasCollection.Get()[0].Id),
                new Hall(16, "4", CinemasCollection.Get()[0].Id),
            };
        }
    }
}
