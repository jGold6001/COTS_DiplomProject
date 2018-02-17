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
    public static class FlorenceLittlePlacesCollection
    {
        public static List<Place> Get()
        {
            int startIndex = 128;
            var places = new List<Place>();

            //row 1 sector green          
            for (int s = 7; s > 0; s--)
            {
                long id = startIndex++;
                int row = 1;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[1].Id, FlorenceSectorsCollection.Get()[0].Id);
                places.Add(place);
            }
            


            //row 2-3 red
            for (int r = 1; r < 3; r++)
            {    
                for (int s = 7; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[1].Id, FlorenceSectorsCollection.Get()[1].Id);
                    places.Add(place);
                }
            }


            //row 4-5 sector blue
            for (int r = 3; r < 5; r++)
            {

                for (int s = 6; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, FlorenceHallsCollection.Get()[1].Id, FlorenceSectorsCollection.Get()[3].Id);
                    places.Add(place);
                }
            }


            //row 6 sector cyan
            for (int s = 7; s > 0; s--)
            {
                long id = startIndex++;
                int row = 6;
                var place = new Place(id, row, s, FlorenceHallsCollection.Get()[1].Id, FlorenceSectorsCollection.Get()[2].Id);
                places.Add(place);
            }


            return places;
        }
    }
}
