﻿using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Sectors;
using COTS.DAL.Test.CollectionForData.Tariffs.Constants;
using COTS.DAL.Test.CollectionForData.Technologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Tariffs.Florence
{
   public static class FlorenceDayWorkdayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("day_workday_green_2d", 50, FlorenceSectorsCollection.Get()[0].Id,WeekDays.WORKING, TimePeriod.Day, TypeD.twoD),
                new Tariff("day_workday_red_2d", 55, FlorenceSectorsCollection.Get()[1].Id,WeekDays.WORKING, TimePeriod.Day, TypeD.twoD),              
            };
        }
    }
}
