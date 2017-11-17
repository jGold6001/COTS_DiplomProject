using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Repositories
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(DbContext context) : base(context)
        {

        }
    }
}
