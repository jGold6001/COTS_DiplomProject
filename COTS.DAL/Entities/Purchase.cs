using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Purchase
    {
        public string Id { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Customer Сustomer { get; set; }
        public decimal Sum { get; set; }
        public Purchase()
        {
            Tickets = new List<Ticket>();
        }
    }
}
