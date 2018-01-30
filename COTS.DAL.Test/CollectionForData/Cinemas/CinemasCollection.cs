 using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Enterprises;
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
                new Cinema("mpx_skymall","Multiplex SkyMall", EnterprisesCollection.Get()[0].Id, "проспект. Генерала Ватутина 2Т","https://s3.amazonaws.com/cinema.tickets.ua/theater/poster/square/theater-1481908967.jpg?1481908968"),
                new Cinema("mpx_prospect", "Multiplex Проспект", EnterprisesCollection.Get()[0].Id, "ул. Гната Хоткевича 1В", "https://s3.amazonaws.com/cinema.tickets.ua/theater/poster/square/theater-1481909021.jpg?1481909025"),
                new Cinema("mpx_dafi", "Multiplex Dafi",EnterprisesCollection.Get()[0].Id, "ул. Героев Труда 9", "https://s3.amazonaws.com/cinema.tickets.ua/theater/poster/square/theater-1482163646.jpg?1482163648"),
                new Cinema("florence", "Флоренция", EnterprisesCollection.Get()[1].Id, "проспект. Маяковского 31", "https://s3.amazonaws.com/cinema.tickets.ua/theater/poster/square/theater-1482163425.jpg?1482163427")
            };
        }
    }
}
