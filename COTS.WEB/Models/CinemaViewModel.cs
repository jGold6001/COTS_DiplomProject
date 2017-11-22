using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class CinemaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }
    }
}