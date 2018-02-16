using COTS.DAL.Entities;
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
    public static class FlorenceEveningHolidayTariffsCollection
    {
       public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("evening_holiday_green_2d", 80, FlorenceSectorsCollection.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_holiday_red_2d", 85, FlorenceSectorsCollection.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_holiday_cyan_2d", 95, FlorenceSectorsCollection.Get()[2].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_holiday_blue_2d", 100, FlorenceSectorsCollection.Get()[3].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),

                new Tariff("evening_holiday_green_3d", 180, FlorenceSectorsCollection.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD),
                new Tariff("evening_holiday_red_3d", 185, FlorenceSectorsCollection.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD),
                new Tariff("evening_holiday_cyan_3d", 195, FlorenceSectorsCollection.Get()[2].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD),
                new Tariff("evening_holiday_blue_3d", 200, FlorenceSectorsCollection.Get()[3].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD),
            };
        }
    }
}
