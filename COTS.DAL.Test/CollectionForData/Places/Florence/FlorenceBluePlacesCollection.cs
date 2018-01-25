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
            var places = new List<Place>();
            for (int r = 0; r < 4; r++)
            {
                for (int n = 0; n < 6; n++)
                {
                    long id = (r + 1) * (n+1);
                    var place = new Place(id, r, n, false, FlorenceHallsCollection.Get()[0].Id);
                    places.Add(place);
                }
            }
            return places;
        }
    }
}
