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

       
        public IEnumerable<Seance> FindAllByHallMovieAndDate(long hallId, long movieId, DateTime date)
        {
            return context.Database.SqlQuery<Seance>(
                "SELECT * FROM dbo.Seances " +
                "INNER JOIN dbo.Halls ON " +
                "dbo.Seances.HallId = dbo.Hall.Id " +
                "INNER JOIN dbo.Movies ON " +
                "dbo.Seances.MovieId = dbo.Movies.ID " +
                "AND dbo.Movies.Id = @movieId " +
                "AND dbo.Hall.Id = @hallId " +
                "AND CONVERT(date, dbo.Seances.DateAndTime) = @date",
                new SqlParameter("@hallId", hallId),
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@date", date)
            ).ToList();
        }

        
    }
}
