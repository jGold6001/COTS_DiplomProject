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
        TicketDTO GetOne(string id);
        IEnumerable<TicketDTO> GetAll();
        bool IsPlaceInTicket(PlaceDTO placeDTO, long seance);
        IEnumerable<TicketDTO> GetByPurchase(string purchaseId);
        IEnumerable<TicketDTO> GetByState(int state);
        void Delete(string id);
    }
}
