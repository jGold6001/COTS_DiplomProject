using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class TicketDTO
    {
        public string Id { get; set; }
        public SeanceDTO SeanceDTO { get; set; } 
        public long? SeanceId { get; set; }
        public TicketPlaceDetailsDTO TicketPlaceDetailsDTO { get; set; }
        public string PurchaseId { get; set; }
        public int State { get; set; }
    }
}
