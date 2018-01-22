using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class PlaceDetailsViewModel
    {
        public long Id { get; set; }
        public string TicketId { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
    }
}