using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Halls
{
    public static class MpxProspectHallsCollection
    {
        public static List<Hall> Get()
        {
            return new List<Hall>()
            {
                new Hall(9, "1", CinemasCollection.Get()[1].Id),
                new Hall(10, "2", CinemasCollection.Get()[1].Id),
                new Hall(11, "3", CinemasCollection.Get()[1].Id),
                new Hall(12, "4", CinemasCollection.Get()[1].Id),
            };
        }
    }
}
