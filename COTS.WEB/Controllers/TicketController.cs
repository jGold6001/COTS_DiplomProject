using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COTS.WEB.Controllers
{
    public class TicketController : Controller
    {
        ITicketService ticketService;
        IMapper mapper;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
            mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, TicketViewModel>()));
        }

        //public ActionResult Get
        
    }
}