using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class PurchaseViewModel
    {
        public string Id { get; set; }
        public TicketViewModel[] TicketViewModels { get; set; }
        
    }
}