using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Constants;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
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

        MapperUnitOfWork mapperUnitOfWork;

        public TicketController()
        {

        }

        public TicketController(ITicketService ticketService, IPurchaseService purchaseService)
        {
            this.ticketService = ticketService;
            this.purchaseService = purchaseService;

            mapperUnitOfWork = new MapperUnitOfWork();

        }

        [Route("all")]
        public IEnumerable<TicketViewModel> GetAllTickets()
        {
            return mapperUnitOfWork.TicketViewModelMapper.MapToCollectionObjects(ticketService.GetAll());
        }

        
        [Route("all_booking")]
        public IEnumerable<TicketViewModel> GetAllBookingTickets()
        {
            return mapperUnitOfWork.TicketViewModelMapper.MapToCollectionObjects(ticketService.GetByState(TicketStates.BOOKING));
        }

        [Route("by_purchase")]
        public IEnumerable<TicketViewModel> GetAllByPurchase()
        {
            return null;
        }

    }
}
