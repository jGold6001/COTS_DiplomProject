using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class TicketViewModel
    {
        public string Id { get; set; }
        public SeanceViewModel SeanceViewModel { get; set; }
        public PlaceDetailsViewModel PlaceDetailsViewModel { get; set; }
        public string PurchaseId { get; set; }
        public int State { get; set; }
    }
}