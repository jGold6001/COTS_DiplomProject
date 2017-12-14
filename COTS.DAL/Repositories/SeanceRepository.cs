using COTS.DAL.Entities;
using COTS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Repositories
{
    public class SeanceRepository : Repository<Seance>
    {
        public SeanceRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Seance> FindByDate(DateTime date)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "WHERE CONVERT(date, dbo.Seances.DateAndTime) = @date"
                ,new SqlParameter("@date", date)
            ).ToList();
        }


        public IEnumerable<Seance> FindAllByMovie(long movieId)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Id = @movieId", new SqlParameter("@movieId", movieId)
            ).ToList();
        }

        public IEnumerable<Seance> FindAllByMovieAndDate(long movieId, DateTime date)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Id = @movieId " +
                "AND CONVERT(date, dbo.Seances.DateAndTime) = @date",
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@date", date)
            ).ToList();
        }

        public IEnumerable<Seance> FindAllByCinema(string cinemaId)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Seances.CinemaId = dbo.Cinemas.Id " +
                "AND dbo.Cinemas.Id = @cinemaId", new SqlParameter("@cinemaId", cinemaId)
            ).ToList();
        }

        public IEnumerable<Seance> FindAllByCinemaAndDate(string cinemaId, DateTime date)
        {
            return context.Database.SqlQuery<Seance>(
               "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Seances.CinemaId = dbo.Cinemas.Id " +
                "AND dbo.Cinemas.Id = @cinemaId "+
                "AND CONVERT(date, dbo.Seances.DateAndTime) = @date",
                new SqlParameter("@cinemaId", cinemaId),
                new SqlParameter("@date", date)
            ).ToList();
        }

        public IEnumerable<Seance> FindAllByCinemaMovieAndDate(string cinemaId, long movieId, DateTime date)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Seances.CinemaId = dbo.Cinemas.Id " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Id = @movieId " +
                "AND dbo.Cinemas.Id = @cinemaId " +
                "AND CONVERT(date, dbo.Seances.DateAndTime) = @date",
                new SqlParameter("@cinemaId", cinemaId),
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@date", date)
            ).ToList();
        }

        
    }
}
