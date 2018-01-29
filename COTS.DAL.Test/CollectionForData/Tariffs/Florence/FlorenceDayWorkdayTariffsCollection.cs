using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Sectors;
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
                new Tariff("day_workday_green", 50, FlorenceSectorsCollection.Get()[0].Id),
                new Tariff("day_workday_red", 55, FlorenceSectorsCollection.Get()[1].Id)
            };
        }
    }
}
