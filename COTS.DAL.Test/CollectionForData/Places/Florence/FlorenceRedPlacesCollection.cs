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
    public static class FlorenceRedPlacesCollection
    {
        public static List<Place> Get()
        {
            int startIndex = 270;
            var places = new List<Place>();

            //row 1-3 green sector          
            for (int s = 1; s <=4; s++)
            {
                long id = startIndex++;
                int row = 1;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[3].Id, FlorenceSectorsCollection.Get()[0].Id);
                places.Add(place);
            }
            for (int s = 1; s <= 6; s++)
            {
                long id = startIndex++;
                int row = 2;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[3].Id, FlorenceSectorsCollection.Get()[0].Id);
                places.Add(place);
            }
            for (int s = 1; s <= 8; s++)
            {
                long id = startIndex++;
                int row = 3;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[3].Id, FlorenceSectorsCollection.Get()[0].Id);
                places.Add(place);
            }



            //row 4-5 blue sector
            for (int r = 3; r < 5; r++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[3].Id);
                    places.Add(place);
                }
            }

            //row 6-7 red sector
            for (int r = 5; r < 7; r++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[1].Id);
                    places.Add(place);
                }
            }

            //row 9 cyan sector
            for (int s = 1; s <= 12; s++)
            {
                long id = startIndex++;
                int row = 8;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[2].Id, FlorenceSectorsCollection.Get()[2].Id);
                places.Add(place);
            }



            return places;
        }
    }
}
