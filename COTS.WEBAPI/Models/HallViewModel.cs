using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class HallViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CinemaViewModel CinemaViewModel { get; set; }
    }
}