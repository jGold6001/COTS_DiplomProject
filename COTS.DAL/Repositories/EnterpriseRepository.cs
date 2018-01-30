using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;

namespace COTS.DAL.Repositories
{
    public class EnterpriseRepository : Repository<Enterprise>
    {
        public EnterpriseRepository(DbContext context) : base(context)
        {
        }
    }
}
