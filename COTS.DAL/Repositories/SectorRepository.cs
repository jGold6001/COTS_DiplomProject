using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace COTS.DAL.Repositories
{
    public class SectorRepository : Repository<Sector>
    {
        public SectorRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Sector> FindAllBySeance(long seanceId)
        {
            return context.Database.SqlQuery<Sector>(
                "SELECT  dbo.Sectors.Id, dbo.Sectors.Name, dbo.Sectors.EnterpriseId FROM dbo.Sectors " +
                "INNER JOIN dbo.Places on dbo.Sectors.Id = dbo.Places.SectorId "+
                "INNER JOIN dbo.Halls on dbo.Halls.Id = dbo.Places.HallId "+
                "INNER JOIN dbo.Seances on dbo.Seances.HallId = dbo.Halls.Id "+
                "AND dbo.Seances.Id = @seanceId " +
                "GROUP BY dbo.Sectors.Id, dbo.Sectors.Name, dbo.Sectors.EnterpriseId"
                , new SqlParameter("@seanceId", seanceId)
            ).ToList();
        }
    }
}
