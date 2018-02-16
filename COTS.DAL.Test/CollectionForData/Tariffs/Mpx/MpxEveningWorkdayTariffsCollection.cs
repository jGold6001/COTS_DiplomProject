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
    public static class MpxEveningWorkdayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("evening_workday_good_2d", 70, MpxSectorsCollections.Get()[0].Id, WeekDays.WORKING, TimePeriod.Evening, TypeD.twoD),
                new Tariff("evening_workday_superlux_2d", 90, MpxSectorsCollections.Get()[1].Id, WeekDays.WORKING, TimePeriod.Evening, TypeD.twoD),

                new Tariff("evening_workday_good_3d", 95, MpxSectorsCollections.Get()[0].Id, WeekDays.WORKING, TimePeriod.Evening, TypeD.threeD),
                new Tariff("evening_workday_superlux_3d", 125, MpxSectorsCollections.Get()[1].Id, WeekDays.WORKING, TimePeriod.Evening, TypeD.threeD),
            };
        }
    }
}
