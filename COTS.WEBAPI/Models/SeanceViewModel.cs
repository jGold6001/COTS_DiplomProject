using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class SeanceViewModel
    {
        public long Id { get; set; }
        public string DateSeance { get; set; }
        public string TimeBegin { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }
    }
}