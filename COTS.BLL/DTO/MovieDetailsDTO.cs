using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class MovieDetailsDTO
    {
        public long Id { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string AgeCategory { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string TrailerUrl { get; set; }
    }
}
