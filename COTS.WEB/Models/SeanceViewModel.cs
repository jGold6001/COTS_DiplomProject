using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class SeanceViewModel
    {
        public long Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }
        public long CinemaId { get; set; }
        public long MovieId { get; set; }

        public SeanceViewModel()
        {

        }

        public SeanceViewModel(DateTime dateAndTime, string typeD, string hall)
        {
            DateAndTime = dateAndTime;
            TypeD = typeD;
            Hall = hall;
        }

        public SeanceViewModel(DateTime dateAndTime, string typeD, string hall, long cinemaId, long movieId) : this(dateAndTime, typeD, hall)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
        }
    }
}