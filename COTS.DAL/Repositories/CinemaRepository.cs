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
    public class CinemaRepository : Repository<Cinema>
    {
        public CinemaRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Cinema> FindAllByCity(string cityName)
        {
            return context.Database.SqlQuery<Cinema>(
                "SELECT * FROM dbo.Cinemas " +
                "INNER JOIN dbo.Cities ON dbo.Cinemas.CityId = dbo.Cities.Id " +
                "AND dbo.Cities.Name = @cityName", new SqlParameter("@cityName", cityName)
            ).ToList();
        }
    }
}
