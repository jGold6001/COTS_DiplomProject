using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Enterprises
{
    public static class EnterprisesCollection
    {
        public static List<Enterprise> Get()
        {
            return new List<Enterprise>()
            {
                new Enterprise("mpx", "Мультиплекс"),
                new Enterprise("kinoKiev", "КиноКиев")
            };
        }
    }
}
