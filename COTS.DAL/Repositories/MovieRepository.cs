using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Movie> FindAllPremeries()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies " +
                "WHERE dbo.Movies.DateIssue <= GETDATE() " +
                "AND DATEADD(day, 15, dbo.Movies.DateIssue) > GETDATE();"
            ).ToList();
        }

        public IEnumerable<Movie> FindAllComingSoon()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies WHERE dbo.Movies.DateIssue > GETDATE();"
            ).ToList();
        }
        
        public IEnumerable<Movie> GetAllByRankOrder()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies ORDER BY dbo.Movies.RankSales DESC;"
            ).ToList();
        }
    }
}
