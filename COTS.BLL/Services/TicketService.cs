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
        IMapper mapperTicket, mapperPlaceDetails;
        IMapper mapperTicketReverse, mapperPlaceDetailsReverse;

        public TicketService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperTicket = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<Ticket, TicketDTO>()));
            mapperTicketReverse = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, Ticket>()));

            mapperPlaceDetails = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketPlaceDetails, TicketPlaceDetailsDTO>()));
            mapperPlaceDetailsReverse = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketPlaceDetailsDTO, TicketPlaceDetails>()));
        }
        public void AddOrUpdate(TicketDTO ticketDTO)
        {
            if(ticketDTO == null)
                throw new ValidationException("TicketsDTO not set", "");

            var ticket = mapperTicketReverse.Map<TicketDTO, Ticket>(ticketDTO);
            var placeDetails = mapperPlaceDetailsReverse.Map<TicketPlaceDetailsDTO, TicketPlaceDetails>(ticketDTO.ticketPlaceDetailsDTO);
            UnitOfWork.TicketPlaceDetails.AddOrUpdate(placeDetails);
            UnitOfWork.Tickets.AddOrUpdate(ticket);
            UnitOfWork.Save();
        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            var ticket = UnitOfWork.Tickets.Get(id);
            var placeDetails = UnitOfWork.TicketPlaceDetails.Get(id);
            UnitOfWork.TicketPlaceDetails.Delete(placeDetails);
            UnitOfWork.Tickets.Delete(ticket);
            UnitOfWork.Save();
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            var tickets = UnitOfWork.Tickets.GetAll();
            if (tickets.Count() == 0)
                return null;

            var ticketsDTOs = AddPlacesDetailesFromDb(tickets);
            return ticketsDTOs;
        }
       

        public TicketDTO GetOne(string id)
        {
            if(id == null)
                throw new ValidationException("'id' not set", "");

            var ticketDTO = mapperTicket.Map<Ticket, TicketDTO>(UnitOfWork.Tickets.Get(id));
            var placeDetailsDTO = mapperPlaceDetails.Map<TicketPlaceDetails, TicketPlaceDetailsDTO>(UnitOfWork.TicketPlaceDetails.Get(ticketDTO.Id));
            ticketDTO.ticketPlaceDetailsDTO = placeDetailsDTO;
            return ticketDTO;
        }

        public IEnumerable<TicketDTO> GetByPurchase(string purchaseId)
        {
            if (purchaseId == null)
                throw new ValidationException("'purchaseId' not set", "");

            var tickets = UnitOfWork.Tickets.FindBy(t => t.PurchaseId == purchaseId);

            var ticketsDTOs = AddPlacesDetailesFromDb(tickets);
            return ticketsDTOs;
        }    

        public IEnumerable<TicketDTO> GetByState(int state)
        {
            var tickets = UnitOfWork.Tickets.FindBy(t => t.State == state);

            var ticketsDTOs = AddPlacesDetailesFromDb(tickets);
            return ticketsDTOs;
        }


        private List<TicketDTO> AddPlacesDetailesFromDb(IEnumerable<Ticket> tickets)
        {           
            var ticketsDTOs = mapperTicket.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets) as List<TicketDTO>;
            foreach (var item in ticketsDTOs)
                item.ticketPlaceDetailsDTO = mapperPlaceDetails.Map<TicketPlaceDetails, TicketPlaceDetailsDTO>(UnitOfWork.TicketPlaceDetails.Get(item.Id));
           
            return ticketsDTOs;
        }
    }
}
