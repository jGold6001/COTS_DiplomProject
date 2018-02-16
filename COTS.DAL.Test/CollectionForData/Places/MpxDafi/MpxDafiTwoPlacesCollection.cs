using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Halls;
using COTS.DAL.Test.CollectionForData.Sectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Places.MpxDafi
{
    public static class MpxDafiTwoPlacesCollection
    {
        public static List<Place> Get()
        {
            int startIndex = 1145;
            var places = new List<Place>();

            //row 1-3 good
            for (int r = 0; r < 3; r++)
            {

                for (int s = 7; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxDafiHallsCollection.Get()[1].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }


            //row 4-5 good
            for (int r = 3; r < 5; r++)
            {

                for (int s = 6; s > 0; s--)
                {
                    long id = startIndex++;
                    int row = (r + 1);
                    var place = new Place(id, row, s, MpxDafiHallsCollection.Get()[1].Id, MpxSectorsCollections.Get()[0].Id);
                    places.Add(place);
                }
            }


            //row 6 super lux
            for (int s = 7; s > 0; s--)
            {
                long id = startIndex++;
                int row = 6;
                var place = new Place(id, row, s, MpxDafiHallsCollection.Get()[1].Id, MpxSectorsCollections.Get()[1].Id);
                places.Add(place);
            }


            return places;
        }
    }
}
