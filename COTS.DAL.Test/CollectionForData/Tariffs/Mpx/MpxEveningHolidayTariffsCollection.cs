using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Sectors;
using COTS.DAL.Test.CollectionForData.Tariffs.Constants;
using COTS.DAL.Test.CollectionForData.Technologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Tariffs.Mpx
{
    public static class MpxEveningHolidayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("evening_holiday_good_2d", 120, MpxSectorsCollections.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_holiday_superlux_2d", 170, MpxSectorsCollections.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_holiday_good_3d", 220, MpxSectorsCollections.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD),
                new Tariff("evening_holiday_superlux_3d", 270, MpxSectorsCollections.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Evening, TypeD.threeD)
            };
        }
    }
}
