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
        public DateTime DateAndTime { get; set; }
        public Hall Hall { get; set; }
        public long? HallId { get; set; }
        public string TypeD { get; set; }       
        public Movie Movie { get; set; }
        public long? MovieId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Seance()
        {
            Tickets = new List<Ticket>();
        }

        public Seance(DateTime dateAndTime, string typeD, long hallId)
        {
            DateAndTime = dateAndTime;
            TypeD = typeD;
            HallId = hallId;
            Tickets = new List<Ticket>();
        }
    }
}
