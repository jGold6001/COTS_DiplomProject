using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(DbContext context) : base(context)
        {

        }

        
    }
}
