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

        public IEnumerable<Seance> FindByMovie(string movieName)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Name = @movieName", new SqlParameter("@movieName", movieName)
            ).ToList();
        }

        public IEnumerable<Seance> FindByMovie(long movieId)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Id = @movieId", new SqlParameter("@movieId", movieId)
            ).ToList();
        }

        public IEnumerable<Seance> FindByCinema(string cinemaName)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Seances.CinemaId = dbo.Cinemas.Id " +
                "AND dbo.Cinemas.Name = @cinemaName", new SqlParameter("@cinemaName", cinemaName)
            ).ToList();
        }

        public IEnumerable<Seance> FindByCinema(long cinemaId)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Seances.CinemaId = dbo.Cinemas.Id " +
                "AND dbo.Cinemas.Id = @cinemaId", new SqlParameter("@cinemaId", cinemaId)
            ).ToList();
        }
    }
}
