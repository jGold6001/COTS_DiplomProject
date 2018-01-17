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
        public string ImagePath { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public int RankSales { get; set; }
        public DateTime DateIssue { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public Movie()
        {
            Seances = new List<Seance>();
        }

        public Movie(string name, string imagePath, int rankSales, DateTime dateIssue)
        {
            Name = name;           
            ImagePath = imagePath;
            RankSales = rankSales;
            DateIssue = dateIssue;
            Seances = new List<Seance>();
        }

        public Movie(string name, string imagePath, int rankSales, DateTime dateIssue, MovieDetails movieDetails)
        {
            Name = name;
            ImagePath = imagePath;
            RankSales = rankSales;
            MovieDetails = movieDetails;
            DateIssue = dateIssue;
            Seances = new List<Seance>();
        }
    }
}
