using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class PurchaseDTO
    {
        public string Id { get; set; }
        public List<TicketDTO> TicketsDTOs { get; set; }
        public PurchaseClientDetailsDTO PurchaseClientDetailsDTO { get; set; }
    }
}
