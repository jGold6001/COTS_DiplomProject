﻿using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.BLL.Utils;
using COTS.DAL.Entities;
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork UnitOfWork { get; set; }
        
        ISeanceService seanceService;
        ITicketPlaceDetailsService ticketPlaceDetailsService;
        MapperUnitOfWork mapperUnitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;          
            seanceService = new SeanceService(unitOfWork);
            ticketPlaceDetailsService = new TicketPlaceDetailsService(unitOfWork);
            mapperUnitOfWork = new MapperUnitOfWork();
        }
        public void AddOrUpdate(TicketDTO ticketDTO)
        {
            if(ticketDTO == null)
                throw new ValidationException("TicketsDTO not set", "");
         
            var ticket = mapperUnitOfWork.TicketMapper.MapToObject(ticketDTO);
            UnitOfWork.Tickets.AddOrUpdate(ticket);
            ticketPlaceDetailsService.AddOrUpdate(ticketDTO.TicketPlaceDetailsDTO);
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

            var ticketsDTOs = AttachObjetcsToDTOList(tickets);
            return ticketsDTOs;
        }
       

        public TicketDTO GetOne(string id)
        {
            if(id == null)
                throw new ValidationException("'id' not set", "");

            var ticket = UnitOfWork.Tickets.Get(id);
            var ticketDTO = AttachObjetcsToDTO(ticket);
            return ticketDTO;
        }

        public IEnumerable<TicketDTO> GetByPurchase(string purchaseId)
        {
            if (purchaseId == null)
                throw new ValidationException("'purchaseId' not set", "");

            var tickets = UnitOfWork.Tickets.FindBy(t => t.PurchaseId == purchaseId);

            var ticketsDTOs = AttachObjetcsToDTOList(tickets);
            return ticketsDTOs;
        }    

        public IEnumerable<TicketDTO> GetByState(int state)
        {
            var tickets = UnitOfWork.Tickets.FindBy(t => t.State == state);

            var ticketsDTOs = AttachObjetcsToDTOList(tickets);
            return ticketsDTOs;
        }



        private TicketDTO AttachObjetcsToDTO(Ticket ticket)
        {
            var ticketDTO = mapperUnitOfWork.TicketDTOMapper.MapToObject(ticket);
            var placeDetailsDTO = mapperUnitOfWork.TicketPlaceDetailsDTOMapper.MapToObject(UnitOfWork.TicketPlaceDetails.Get(ticketDTO.Id));
            var seanceDTO = seanceService.GetOne(ticket.SeanceId);

            ticketDTO.TicketPlaceDetailsDTO = placeDetailsDTO;
            ticketDTO.SeanceDTO = seanceDTO; 
            return ticketDTO;
        }

        private IEnumerable<TicketDTO> AttachObjetcsToDTOList(IEnumerable<Ticket> tickets)
        {
            var ticketsDTOs = mapperUnitOfWork.TicketDTOMapper.MapToCollectionObjects(tickets);           

            foreach (var item in ticketsDTOs)
            {
                item.TicketPlaceDetailsDTO = ticketPlaceDetailsService.GetOne(item.Id);
                item.SeanceDTO = seanceService.GetOne(item.SeanceId);
            }
               
            return ticketsDTOs;
        }

       
    }
}
