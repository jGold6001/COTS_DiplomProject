using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Test.CollectionForData.Sectors;

namespace COTS.DAL.Test.CollectionForData.Tariffs.Florence
{
    public static class FlorenceDayHolidayTariffsCollection
    {
        public static List<Tariff> Get()
        {
            return new List<Tariff>()
            {
                new Tariff("day_holiday_green", 70, FlorenceSectorsCollection.Get()[0].Id),
                new Tariff("day_holiday_red", 75, FlorenceSectorsCollection.Get()[1].Id)
            };
        }
    }
}
