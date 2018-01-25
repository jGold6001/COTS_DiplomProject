using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Halls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Places.Florence
{
    public static class FlorenceBluePlacesCollection
    {
        public static List<Place> Get()
        {
            int counter = 1;
            var places = new List<Place>();
            for (int r = 0; r < 4; r++)
            {
                for (int n = 0; n < 6; n++)
                {                    
                    int row = (r + 1);
                    int num = (n + 1);
                    long id = counter++;
                    var place = new Place(id, row, num, false, FlorenceHallsCollection.Get()[0].Id);
                    places.Add(place);
                }
            }
            return places;
        }
    }
}
