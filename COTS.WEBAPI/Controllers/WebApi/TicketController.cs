using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Constants;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using COTS.WEBAPI.Utils.MapperManeger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/ticket")]
    public class TicketController : ApiController
    {
        ITicketService ticketService;
        IPurchaseService purchaseService;

        SeanceViewModelMapper seanceViewModelMapper;
        TicketViewModelMapper ticketViewModelMapper;
        TicketDTOMapper ticketDTOMapper;
        PurchaseViewModelMapper purchaseViewModelMapper;
        PurchaseDTOMapper purchaseDTOMapper;

        MapperUnitOfWork mapperUnitOfWork;

        public TicketController()
        {

        }

        public TicketController(ITicketService ticketService, IPurchaseService purchaseService)
        {
            this.ticketService = ticketService;
            this.purchaseService = purchaseService;

            mapperUnitOfWork = new MapperUnitOfWork();

            seanceViewModelMapper = new SeanceViewModelMapper();
            ticketViewModelMapper = new TicketViewModelMapper(seanceViewModelMapper);
            ticketDTOMapper = new TicketDTOMapper();
            purchaseViewModelMapper = new PurchaseViewModelMapper(ticketViewModelMapper);
            purchaseDTOMapper = new PurchaseDTOMapper();
        }

        [Route("all")]
        public IEnumerable<TicketViewModel> GetAllTickets()
        {
            //return mapperUnitOfWork.TicketViewModelMapper.MapToCollectionObjects(ticketService.GetAll());
            return ticketViewModelMapper.MapToCollectionObjects(ticketService.GetAll());
        }

        [Route("all_purchases")]
        public IEnumerable<PurchaseViewModel> GetAll()
        {
            return purchaseViewModelMapper.MapToCollectionObjects(purchaseService.GetAll());
        }

        [HttpPost]
        [Route("save_in_db")]
        public void SaveInDb(PurchaseViewModel purchaseViewModel)
        {        
            purchaseService.AddOrUpdate(purchaseDTOMapper.MapToObject(purchaseViewModel)); 
        }


        [Route("all_booking")]
        public IEnumerable<TicketViewModel> GetAllBookingTickets()
        {
            return ticketViewModelMapper.MapToCollectionObjects(ticketService.GetByState(TicketStates.BOOKING));         
        }

        [Route("by_purchase")]
        public IEnumerable<TicketViewModel> GetAllByPurchase()
        {
            return null;
        }

        [Route("get_purchase/{purchaseId}")]
        public PurchaseViewModel GetPurchase(string purchaseId)
        {
            return purchaseViewModelMapper.MapToObject(purchaseService.GetOne(purchaseId));           
        }


    }
}
