using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class PlaceViewModel
    {
        public long Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsBusy { get; set; }
        public long? HallId { get; set; }

    }
}