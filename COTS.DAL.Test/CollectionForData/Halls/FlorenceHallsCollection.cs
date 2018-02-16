using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Halls
{
    public static class FlorenceHallsCollection
    {
        public static List<Hall> Get()
        {
            return new List<Hall>()
            {
                new Hall(1, "Зеленый", CinemasCollection.Get()[3].Id),            
                new Hall(2, "Малый", CinemasCollection.Get()[3].Id),
                new Hall(3, "Синий", CinemasCollection.Get()[3].Id),
                new Hall(4, "Красный", CinemasCollection.Get()[3].Id),                               
            };
        }
    }
}
