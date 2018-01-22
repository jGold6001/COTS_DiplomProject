using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class TicketPlaceDetails
    {
        [Key]
        [ForeignKey("Ticket")]
        public string TicketId { get; set; }
        public int Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
        public Ticket Ticket { get; set; }
    }
}
