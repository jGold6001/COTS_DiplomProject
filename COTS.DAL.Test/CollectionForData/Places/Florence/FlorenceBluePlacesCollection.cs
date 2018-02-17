using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Halls;
using COTS.DAL.Test.CollectionForData.Sectors;
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
            int startIndex = 168;
            var places = new List<Place>();

            //row 1-3 green sector
            for (int r = 0; r < 3; r++)
            {

                for (int s = 1; s <= 10; s++)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[0].Id);
                    places.Add(place);
                }
            }

            //row 4-6 blue sector
            for (int r = 3; r < 6; r++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[3].Id);
                    places.Add(place);
                }
            }

            //row 7-9 red sector
            for (int r = 6; r < 9; r++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[1].Id);
                    places.Add(place);
                }
            }

            //row 10 cyan sector
            for (int s = 1; s <= 12; s++)
            {
                long id = startIndex++;
                int row = 10;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[2].Id);
                places.Add(place);
            }



            return places;
        }
    }
}
