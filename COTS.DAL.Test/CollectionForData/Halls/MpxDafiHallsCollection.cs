using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Halls
{
    public static class MpxDafiHallsCollection
    {
        public static List<Hall> Get()
        {
            return new List<Hall>()
            {
                new Hall(5, "1", CinemasCollection.Get()[2].Id),
                new Hall(6, "2", CinemasCollection.Get()[2].Id),
                new Hall(7, "3", CinemasCollection.Get()[2].Id),
                new Hall(8, "4", CinemasCollection.Get()[2].Id),
            };
        }
    }
}
