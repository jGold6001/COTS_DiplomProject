using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ITicketService
    {
        void AddOrUpdate(TicketDTO ticketDTO);
        TicketDTO GetOne(long? id);
        IEnumerable<TicketDTO> GetAll();
        void Delete(long? id);
    }
}
