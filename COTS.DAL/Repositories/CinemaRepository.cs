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
    }
}
