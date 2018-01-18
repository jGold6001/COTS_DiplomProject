using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class MovieShortViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }       
        public string ImagePath { get; set; }
        public int RankSales { get; set; }
        public string DateIssue { get; set; }
    }
}