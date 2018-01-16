using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Ticket
    {
        public string Id { get; set; }
        public Seance Seance { get; set; }
        public long? SeanceId { get; set; }
        public TicketPlaceDetails TicketPlaceDetails { get; set; }
        public Purchase Purchase { get; set; }
        public string PurchaseId { get; set; }
        public int State { get; set; }
    }
}
