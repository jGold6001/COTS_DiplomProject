using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class MovieFullViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Destination { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string AgeCategory { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string TrailerUrl { get; set; }
        public string ImagePath {get;set;}
        public int RankSales { get; set; }
        public string DateIssue { get; set; }
    }
}