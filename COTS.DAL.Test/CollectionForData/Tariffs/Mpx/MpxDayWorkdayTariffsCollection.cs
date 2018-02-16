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
    public static class MpxDayWorkdayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("day_workday_good_2d", 50, MpxSectorsCollections.Get()[0].Id, WeekDays.WORKING, TimePeriod.Day, TypeD.twoD),
                new Tariff("day_workday_superlux_2d", 70, MpxSectorsCollections.Get()[1].Id, WeekDays.WORKING, TimePeriod.Day, TypeD.twoD),

                new Tariff("day_workday_good_3d", 75, MpxSectorsCollections.Get()[0].Id, WeekDays.WORKING, TimePeriod.Day, TypeD.threeD),
                new Tariff("day_workday_superlux_3d", 105, MpxSectorsCollections.Get()[1].Id, WeekDays.WORKING, TimePeriod.Day, TypeD.threeD),
            };
        }
    }
}
