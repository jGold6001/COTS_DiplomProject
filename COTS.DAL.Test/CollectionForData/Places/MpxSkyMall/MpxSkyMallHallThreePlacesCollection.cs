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
    public static class MpxSkyMallHallThreePlacesCollection
    {
        public static List<Place> Get()
        {
            int startIndex = 507;
            var places = new List<Place>();

            //row 1-9 green sector
            for (int r = 0; r < 9; r++)
            {
                for (int s = 10; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[2].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }
        

            //row 10 cyan sector
            for (int s = 12; s > 0; s--)
            {
                long id = startIndex++;
                int row = 10;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[2].Id, MpxSectorsCollections.Get()[0].Id);
                places.Add(place);
            }

            return places;
        }
    }
}
