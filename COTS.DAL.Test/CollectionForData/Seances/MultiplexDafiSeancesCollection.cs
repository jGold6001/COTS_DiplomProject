using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Seances
{
    public static class MultiplexDafiSeancesCollection
    {
        public static List<Seance> Get()
        {
            DateTime dateCurrent = DateTime.Now.Date;
            DateTime datePlusOne = DateTime.Now.AddDays(1).Date;
            DateTime datePlusTwo = DateTime.Now.AddDays(2).Date;

            return new List<Seance>()
            {
                //---Бегущий по лезвию
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, "2"),
                new Seance(dateCurrent.AddHours(16), TypeD.twoD, "2"),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, "3"),
                new Seance(datePlusOne.AddHours(16).AddMinutes(40), TypeD.twoD, "3"),
                new Seance(datePlusTwo.AddHours(10), TypeD.twoD, "3"),
				
				//---My Little Pony в кино
				new Seance(datePlusTwo.AddHours(11), TypeD.threeD, "4"),
                new Seance(datePlusTwo.AddHours(12).AddMinutes(10), TypeD.threeD, "4"),
                new Seance(datePlusTwo.AddHours(11.50), TypeD.twoD, "7"),
                new Seance(datePlusTwo.AddHours(13).AddMinutes(10), TypeD.twoD, "7"),

                //--Каматозники
                new Seance(dateCurrent.AddHours(11), TypeD.twoD, "6"),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, "6"),
                new Seance(datePlusOne.AddHours(16).AddMinutes(40), TypeD.twoD, "6"),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, "6"),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, "6")

            };
        }
    }
}
