using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Cinemas
{
    public static class CinemasCollection
    {
        public static List<Cinema> Get()
        {
            return new List<Cinema>() {
                new Cinema("mpx_skymall","Multiplex SkyMall", "ул.Ватутина 2Т"),
                new Cinema("mpx_prospect","Multiplex Проспект", "ул. Гната Хоткевича 1В"),
                new Cinema("mpx_dafi","Multiplex Dafi", "ул. Героев Труда 9"),
                new Cinema("florence","Флоренция", "ул.Маяковского 31")
            };
        }
    }
}
