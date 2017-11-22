using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class SeamceViewModel
    {
        public long Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }
        public long CinemaId { get; set; }
        public long MovieId { get; set; }
    }
}