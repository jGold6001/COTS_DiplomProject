using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class TicketViewModel
    {
        public long Id { get; set; }
        public long SeanceId { get; set; }
        public string Hall { get; set; }
        public int Raw { get; set; }
        public int Place { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
    }
}