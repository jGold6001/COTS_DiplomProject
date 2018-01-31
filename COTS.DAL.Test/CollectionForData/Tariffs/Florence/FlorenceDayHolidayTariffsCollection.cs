using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Test.CollectionForData.Sectors;
using COTS.DAL.Test.CollectionForData.Technologies;
using COTS.DAL.Test.CollectionForData.Tariffs.Constants;

namespace COTS.DAL.Test.CollectionForData.Tariffs.Florence
{
    public static class FlorenceDayHolidayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("day_holiday_green_2d", 70, FlorenceSectorsCollection.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.twoD),
                new Tariff("day_holiday_red_2d", 75, FlorenceSectorsCollection.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.twoD)
            };
        }
    }
}
