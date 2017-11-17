using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Seance
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }
        public Cinema Cinema { get; set; }
        public int? CinemaId { get; set; }
        public Seance()
        {
                
        }

        public Seance(DateTime date, DateTime timeStart, string typeD, string hall)
        {
            Date = date;
            TimeStart = timeStart;
            TypeD = typeD;
            Hall = hall;
        }
    }
}
