using COTS.DAL.Entities;
using COTS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
