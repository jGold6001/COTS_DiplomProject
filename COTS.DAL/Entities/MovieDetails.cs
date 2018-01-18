using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class MovieDetails
    {
        [Key]
        [ForeignKey("Movie")]
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
        public Movie Movie { get; set; }

        public MovieDetails()
        {

        }

        public MovieDetails(string genre, string description,  int year, int duration, string ageCategory, string country, string director, string actors, string trailerUrl)
        {
            Genre = genre;
            Description = description;
            Year = year;
            Duration = duration;
            AgeCategory = ageCategory;
            Country = country;
            Director = director;
            Actors = actors;
            TrailerUrl = trailerUrl;
        }

    }
}
