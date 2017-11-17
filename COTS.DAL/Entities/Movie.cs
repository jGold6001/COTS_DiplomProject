using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Movie
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
        public int RankSales { get; set; }        
        public DateTime DateIssue { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public Movie()
        {
            Seances = new List<Seance>();
        }

        public Movie(string name, string genre, string destination, int year, int duration, string ageCategory, string country, string director, string actors, string trailerUrl, int rankSales, DateTime dateIssue)
        {
            Name = name;
            Genre = genre;
            Destination = destination;
            Year = year;
            Duration = duration;
            AgeCategory = ageCategory;
            Country = country;
            Director = director;
            Actors = actors;
            TrailerUrl = trailerUrl;
            RankSales = rankSales;
            DateIssue = dateIssue;
            Seances = new List<Seance>();
        }
    }
}
