using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class SeanceViewModel
    {
        public long Id { get; set; }
        public DateTime DateSeance { get; set; }    
        public string TimeBegin { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }
        public string CinemaId { get; set; }
        public long MovieId { get; set; }
    }
}