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
        public IEnumerable<TicketDTO> TicketsDTOs { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public decimal Sum { get; set; }
    }
}
