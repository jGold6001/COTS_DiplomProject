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
        public PlaceDTO PlaceDTO { get; set; }
        public long? PlaceId { get; set; }
        public string PurchaseId { get; set; }
        public long? TariffId { get; set; }
        public TariffDTO TariffDTO { get; set; }
        public int State { get; set; }
    }
}
