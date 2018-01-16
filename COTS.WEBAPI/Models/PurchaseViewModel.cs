using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class PurchaseViewModel
    {
        public string Id { get; set; }
        public List<TicketViewModel> TicketViewModels { get; set; }
        public ClientDataViewModel ClientDataViewModel { get; set; }

    }
}