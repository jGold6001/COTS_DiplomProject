using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.BLL.Infrastructure;
using COTS.DAL.Entities;

namespace COTS.BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper;
        IMapper mapperReverse;

        public TicketService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<Ticket, TicketDTO>()));
            mapperReverse = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, Ticket>()));
        }
        public void AddOrUpdate(TicketDTO ticketDTO)
        {
            if(ticketDTO == null)
                throw new ValidationException("TicketsDTO not set", "");

            var ticket = mapperReverse.Map<TicketDTO, Ticket>(ticketDTO);
            UnitOfWork.Tickets.AddOrUpdate(ticket);
            UnitOfWork.Save();
        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            var ticket = UnitOfWork.Tickets.Get(id);
            UnitOfWork.Tickets.Delete(ticket);
            UnitOfWork.Save();
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            var tickets = UnitOfWork.Tickets.GetAll();
            if (tickets.Count() == 0)
                return null;

            return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
        }
       

        public TicketDTO GetOne(string id)
        {
            if(id == null)
                throw new ValidationException("'id' not set", "");

            return mapper.Map<Ticket, TicketDTO>(UnitOfWork.Tickets.Get(id));
        }

        public IEnumerable<TicketDTO> GetByPurchase(string purchaseId)
        {
            if (purchaseId == null)
                throw new ValidationException("'purchaseId' not set", "");

            var tickets = UnitOfWork.Tickets.FindBy(t => t.PurchaseId == purchaseId);
            return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
        }

        public IEnumerable<TicketDTO> GetByState(int state)
        {
            var tickets = UnitOfWork.Tickets.FindBy(t => t.State == state);
            return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
        }
    }
}
