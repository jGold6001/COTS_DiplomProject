using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class TicketPlaceDetailsDTO
    {
        public string Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
    }
}
