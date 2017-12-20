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
        public string Hall { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
        public Purchase Purchase { get; set; }
        public string PurchaseId { get; set; }
        public int State { get; set; }
    }
}
