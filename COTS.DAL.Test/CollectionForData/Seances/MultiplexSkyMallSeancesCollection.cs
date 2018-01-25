using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Test.CollectionForData.Halls;

namespace COTS.DAL.Test.CollectionForData.Seances
{
    public static class MultiplexSkyMallSeancesCollection
    {
        public static List<Seance> Get()
        {
            DateTime dateCurrent = DateTime.Now.Date;
            DateTime datePlusOne = DateTime.Now.AddDays(1).Date;
            DateTime datePlusTwo = DateTime.Now.AddDays(2).Date;
            return new List<Seance>()
            {
                //---Бегущий по лезвию
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[0].Id),
                new Seance(dateCurrent.AddHours(16), TypeD.twoD, MpxSkyMallHallsCollection.Get()[0].Id),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[0].Id),
                new Seance(datePlusOne.AddHours(16).AddMinutes(40), TypeD.twoD, MpxSkyMallHallsCollection.Get()[0].Id),
                new Seance(datePlusTwo.AddHours(10), TypeD.twoD, MpxSkyMallHallsCollection.Get()[0].Id),
				
				//---My Little Pony в кино
				new Seance(datePlusTwo.AddHours(11), TypeD.threeD, MpxSkyMallHallsCollection.Get()[1].Id),
                new Seance(datePlusTwo.AddHours(12).AddMinutes(10), TypeD.threeD, MpxSkyMallHallsCollection.Get()[1].Id),
                new Seance(datePlusTwo.AddHours(11.50), TypeD.twoD, MpxSkyMallHallsCollection.Get()[3].Id),
                new Seance(datePlusTwo.AddHours(13).AddMinutes(10), TypeD.twoD, MpxSkyMallHallsCollection.Get()[3].Id),
				
				//---Салют-7	
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[2].Id),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[2].Id),
                new Seance(datePlusOne.AddHours(16).AddMinutes(40), TypeD.twoD, MpxSkyMallHallsCollection.Get()[2].Id),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[2].Id),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, MpxSkyMallHallsCollection.Get()[2].Id)
            };
        }
    }
}
