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
using COTS.BLL.Managers.MapperManager;
using COTS.BLL.Constants;

namespace COTS.BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork UnitOfWork { get; set; }
        
        ISeanceService seanceService;
        IPlaceService placeService;
        ITariffService tariffService;
        MapperUnitOfWork mapperUnitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;          
            seanceService = new SeanceService(unitOfWork);
            placeService = new PlaceService(unitOfWork);
            tariffService = new TariffService(unitOfWork);
            mapperUnitOfWork = new MapperUnitOfWork();
        }
        public void AddOrUpdate(TicketDTO ticketDTO)
        {
            if(ticketDTO == null)
                throw new ValidationException("TicketsDTO not set", "");
         
            var ticket = mapperUnitOfWork.TicketMapper.MapToObject(ticketDTO);

            
            if (ticket.State == TicketStates.BOOKING)
                ticket.State = TicketStates.SOLD;

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
            var placeDTO = placeService.GetOne(ticket.PlaceId);
            var seanceDTO = seanceService.GetOne(ticket.SeanceId);
            var tariffDTO = tariffService.GetOne(ticket.TariffId);

            ticketDTO.PlaceDTO = placeDTO;
            ticketDTO.SeanceDTO = seanceDTO;
            ticketDTO.TariffDTO = tariffDTO;
            return ticketDTO;
        }

        private IEnumerable<TicketDTO> AttachObjetcsToDTOList(IEnumerable<Ticket> tickets)
        {
            var ticketsDTOs = mapperUnitOfWork.TicketDTOMapper.MapToCollectionObjects(tickets);           

            foreach (var item in ticketsDTOs)
            {
                item.PlaceDTO = placeService.GetOne(item.PlaceId);
                item.SeanceDTO = seanceService.GetOne(item.SeanceId);
                item.TariffDTO = tariffService.GetOne(item.TariffId);
            }
               
            return ticketsDTOs;
        }

        public bool IsPlaceInTicket(PlaceDTO placeDTO, long seanceId)
        {
            var ticketDTO = UnitOfWork.Tickets.FindBy(t => t.PlaceId == placeDTO.Id && t.SeanceId == seanceId);
            if (ticketDTO.Count() == 0)
                return false;

           return true;

        }
    }
}
