using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Repositories
{
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(DbContext context) : base(context)
        {

        }

        //public Movie GetOneByCity(long id, string cityId)
        //{
        //    return context.Database.SqlQuery<Movie>(
        //        "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales " +
        //        "FROM dbo.Movies " +
        //        "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
        //        "INNER JOIN dbo.Cinemas on dbo.Cinemas.Id = dbo.Seances.CinemaId " +
        //        "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
        //        "AND dbo.Movies.Id = @id " +
        //        "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales "
        //        ,new SqlParameter("@id", id), new SqlParameter("@cityId", cityId) 
        //    ).FirstOrDefault();
        //}

        public IEnumerable<Movie> FindAllByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales " +
                "FROM dbo.Movies " +
                "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                "INNER JOIN dbo.Cinemas on dbo.Cinemas.Id = dbo.Seances.CinemaId " +
                "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales "
                , new SqlParameter("@cityId", cityId)
            ).ToList();
        }

        public IEnumerable<Movie> FindAllPremeries()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies " +
                "WHERE dbo.Movies.DateIssue <= GETDATE() " +
                "AND DATEADD(day, 15, dbo.Movies.DateIssue) > GETDATE();"
            ).ToList();
        }

        public IEnumerable<Movie> FindAllPremeriesByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Cinemas on dbo.Cinemas.Id = dbo.Seances.CinemaId " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "AND dbo.Movies.DateIssue <= GETDATE() AND DATEADD(day, 15, dbo.Movies.DateIssue) > GETDATE() " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales "
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }

        public IEnumerable<Movie> FindAllComingSoon()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies WHERE dbo.Movies.DateIssue > GETDATE();"
            ).ToList();
        }

        public IEnumerable<Movie> FindAllComingSoonByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Cinemas on dbo.Cinemas.Id = dbo.Seances.CinemaId " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "AND dbo.Movies.DateIssue > GETDATE() " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales "
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }

        public IEnumerable<Movie> GetTop10ByRankOrder()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT TOP(10) * FROM dbo.Movies ORDER BY dbo.Movies.RankSales DESC;"
            ).ToList();
        }

        public IEnumerable<Movie> GetTop10ByRankOrderByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Cinemas on dbo.Cinemas.Id = dbo.Seances.CinemaId " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.Genre, dbo.Movies.Destination, dbo.Movies.Year, dbo.Movies.Duration, dbo.Movies.AgeCategory, dbo.Movies.Country, dbo.Movies.Director, dbo.Movies.Actors, dbo.Movies.TrailerUrl, dbo.Movies.ImagePath, dbo.Movies.DateIssue, dbo.Movies.RankSales "+
                 "ORDER BY dbo.Movies.RankSales DESC;"
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }
    }
}
