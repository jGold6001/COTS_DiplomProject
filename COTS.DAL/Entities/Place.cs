using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Place
    {
        public long Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsBusy { get; set; }
        public long HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }
        public Place()
        {
            Tariffs = new List<Tariff>();
        }
    }
}
