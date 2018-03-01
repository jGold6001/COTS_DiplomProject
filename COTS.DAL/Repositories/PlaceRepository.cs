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
    public class PlaceRepository : Repository<Place>
    {
        public PlaceRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Place> GetAllByCityCinemaAndHall(string cityId, string cinemaId, string hallName)
        {
            return context.Database.SqlQuery<Place>(
                "SELECT * FROM dbo.Places " +
                "INNER JOIN dbo.Halls ON " +
                "dbo.Halls.Id = dbo.Places.HallId " +
                "INNER JOIN dbo.Cinemas ON " +
                "dbo.Cinemas.Id = dbo.Halls.CinemaId " +
                "INNER JOIN dbo.Cities ON " +
                "dbo.Cinemas.CityId = dbo.Cities.Id " +
                "AND dbo.Cities.Id = @cityId " +
                "AND dbo.Cinemas.Id = @cinemaId " +
                "AND dbo.Halls.Name = @hallName",
                new SqlParameter("@cityId", cityId),
                new SqlParameter("@cinemaId", cinemaId),
                new SqlParameter("@hallName", hallName)
            ).ToList();
        }


        public IEnumerable<Place> GetAllByHall(long hallId)
        {
            return context.Database.SqlQuery<Place>(
                "SELECT * FROM dbo.Places " +
                "WHERE dbo.Places.HallId = @hallId",                            
                new SqlParameter("@hallId", hallId)
            ).ToList();
        }

    }
}
