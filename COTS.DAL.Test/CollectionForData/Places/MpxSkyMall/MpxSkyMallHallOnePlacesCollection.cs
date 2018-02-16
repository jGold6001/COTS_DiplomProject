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
    public class MpxSkyMallHallOnePlacesCollection
    {
        public static List<Place> Get()
        {
            var startIndex = 340;
            var places = new List<Place>();

            //row 1-6 good sector
            for (int r = 0; r < 6; r++)
            {
                for (int s = 12; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[0].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }


            //row 7-9 good sector
            for (int r = 6; r < 9; r++)
            {
                for (int s = 14; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[0].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }

            //row 10 super lux sector
            for (int s = 13; s > 0; s--)
            {
                long id = startIndex++;
                int row = 10;
                var place = new Place(id, row, s, MpxSkyMallHallsCollection.Get()[0].Id, MpxSectorsCollections.Get()[1].Id);
                places.Add(place);
            }

            return places;
        }
    }
}
