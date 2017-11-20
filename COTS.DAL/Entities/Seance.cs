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
        public string TypeD { get; set; }
        public string Hall { get; set; }
        public Cinema Cinema { get; set; }
        public long? CinemaId { get; set; }

        public Movie Movie { get; set; }
        public long? MovieId { get; set; }
        public Seance()
        {
                
        }

        public Seance(DateTime dateAndTime, string typeD, string hall)
        {
            DateAndTime = dateAndTime;
            TypeD = typeD;
            Hall = hall;
        }
    }
}
