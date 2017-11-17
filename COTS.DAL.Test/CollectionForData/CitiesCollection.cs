using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData
{
    public static class CitiesCollection
    {
        public static List<City> Get()
        {
            return new List<City>() {
                new City("Киев"),
                new City("Харьков")
            };
        }
    }
}
