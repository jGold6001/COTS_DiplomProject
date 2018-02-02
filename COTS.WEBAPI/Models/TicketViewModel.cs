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
        public long? SeanceId { get; set; }
        public PlaceViewModel PlaceViewModel { get; set; }
        public long? PlaceId { get; set; }
        public string PurchaseId { get; set; }
        public TariffViewModel TariffViewModel { get; set; }
        public long? TariffId { get; set; }
        public int State { get; set; }
    }
}