using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Halls;
using COTS.DAL.Test.CollectionForData.Seances;
using COTS.DAL.Test.CollectionForData.Technologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace COTS.DAL.Test.CollectionForData.Seances
{
    public static class FlorenceSeancesCollection
    {
        
        public static List<Seance> Get()
        {
            DateTime dateCurrent = DateTime.Now.Date;
            DateTime datePlusOne = DateTime.Now.AddDays(1).Date;
            DateTime datePlusTwo = DateTime.Now.AddDays(2).Date;
          
            return new List<Seance>()
            {
                //---Бегущий по лезвию
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, FlorenceHallsCollection.Get()[3].Id),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, FlorenceHallsCollection.Get()[3].Id),
                new Seance(datePlusTwo.AddHours(10), TypeD.twoD, FlorenceHallsCollection.Get()[3].Id),
				
				//---My Little Pony в кино
				new Seance(datePlusTwo.AddHours(11), TypeD.threeD, FlorenceHallsCollection.Get()[1].Id),
                new Seance(datePlusTwo.AddHours(11.50), TypeD.twoD, FlorenceHallsCollection.Get()[2].Id),
				
				//---Салют-7	
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, FlorenceHallsCollection.Get()[0].Id),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, FlorenceHallsCollection.Get()[0].Id),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, FlorenceHallsCollection.Get()[0].Id)
            };
        }
    }
}
