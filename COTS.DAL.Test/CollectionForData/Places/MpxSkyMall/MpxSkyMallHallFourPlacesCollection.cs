using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Halls;
using COTS.DAL.Test.CollectionForData.Sectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Places.MpxSkyMall
{
    public static class MpxSkyMallHallFourPlacesCollection
    {
        public static List<Place> Get()
        {
            int startIndex = 609;
            var places = new List<Place>();

            //row 1-3 green sector          
            for (int s = 4; s > 0; s--)
            {
                long id = startIndex++;
                int row = 1;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[3].Id, MpxSectorsCollections.Get()[0].Id);
                places.Add(place);
            }
            for (int s = 6; s > 0; s--)
            {
                long id = startIndex++;
                int row = 2;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[3].Id, MpxSectorsCollections.Get()[0].Id);
                places.Add(place);
            }
            for (int s = 8; s > 0; s--)
            {
                long id = startIndex++;
                int row = 3;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[3].Id, MpxSectorsCollections.Get()[0].Id);
                places.Add(place);
            }



            //row 4-7 blue sector
            for (int r = 3; r < 7; r++)
            {
                for (int s = 10; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[3].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }
          

            //row 9 cyan sector
            for (int s = 12; s > 0; s--)
            {
                long id = startIndex++;
                int row = 8;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[3].Id, MpxSectorsCollections.Get()[1].Id);
                places.Add(place);
            }



            return places;
        }
    }
}
