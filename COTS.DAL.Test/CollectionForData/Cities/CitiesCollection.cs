using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Cities
{
    public static class CitiesCollection
    {
        public static List<City> Get()
        {
            return new List<City>() {
                new City("kiev","Киев"),
                new City("harkov","Харьков")
            };
        }
    }
}
