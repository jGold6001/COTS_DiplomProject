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
    public static class MpxDayHolidayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("day_holiday_good_2d", 100, MpxSectorsCollections.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.twoD),
                new Tariff("day_holiday_superlux_2d", 150, MpxSectorsCollections.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.twoD),
                new Tariff("day_holiday_good_3d", 200, MpxSectorsCollections.Get()[0].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.threeD),
                new Tariff("day_holiday_superlux_3d", 250, MpxSectorsCollections.Get()[1].Id, WeekDays.HOLIDAY, TimePeriod.Day, TypeD.threeD)
            };
        }
    }
}
