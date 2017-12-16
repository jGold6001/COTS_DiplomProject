using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class TicketViewModel
    {
        public string Id { get; set; }
        public string Movie { get; set; }
        public string Cinema { get; set; }
        public long SeanceId { get; set; }
        public string Hall { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
        public string PurchaseId { get; set; }
    }
}