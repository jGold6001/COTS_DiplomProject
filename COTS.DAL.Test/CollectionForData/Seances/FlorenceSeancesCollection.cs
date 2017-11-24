﻿using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Seances;
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

            String bigHall = "Большой";
            String littleHall = "Малый";
            String redHall = "Крастный";
            String blueHall = "Синий";
            return new List<Seance>()
            {
                //---Бегущий по лезвию
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, bigHall),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, bigHall),
                new Seance(datePlusTwo.AddHours(10), TypeD.twoD, bigHall),
				
				//---My Little Pony в кино
				new Seance(datePlusTwo.AddHours(11), TypeD.threeD, redHall),
                new Seance(datePlusTwo.AddHours(11.50), TypeD.twoD, littleHall),
				
				//---Салют-7	
				new Seance(dateCurrent.AddHours(11), TypeD.twoD, blueHall),
                new Seance(datePlusOne.AddHours(11), TypeD.twoD, blueHall),
                new Seance(datePlusTwo.AddHours(11), TypeD.twoD, blueHall)
            };
        }
    }
}