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
    [RoutePrefix("ticket")]
    public class TicketController : Controller
    {
        ITicketService ticketService;
        ISeanceService seanceService;
        IMovieService movieService;
        ICinemaService cinemaService;
        IPurchaseService purchaseService;

        IMapper mapper, mapperReverse;

        public TicketController(ITicketService ticketService, ISeanceService seanceService, IMovieService movieService, ICinemaService cinemaService, IPurchaseService purchaseService)
        {
            this.ticketService = ticketService;
            this.seanceService = seanceService;
            this.movieService = movieService;
            this.cinemaService = cinemaService;
            this.purchaseService = purchaseService;

            mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, TicketViewModel>()
                 .ForMember("Cinema", opt => opt.MapFrom(src => cinemaService.GetOne(seanceService.GetOne(src.SeanceId).CinemaId).Name))
                 .ForMember("Movie", opt => opt.MapFrom(src => movieService.GetOne(seanceService.GetOne(src.SeanceId).MovieId).Name))
            ));

            mapperReverse = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketViewModel, TicketDTO>()));
        }

        [HttpPost]         
        public ActionResult SaveInDb(IEnumerable<TicketViewModel> tickets)
        {
            PurchaseDTO purchaseDTO = new PurchaseDTO()
            {
                Id = Guid.NewGuid().ToString()
            };
            purchaseService.AddOrUpdate(purchaseDTO);

            foreach (var item in tickets)
            {
                var ticket = mapperReverse.Map<TicketViewModel, TicketDTO>(item);
                ticket.PurchaseId = purchaseDTO.Id;
                ticketService.AddOrUpdate(ticket);
            }
            return Content("Data are saving in DataBase!!!");
        }

        [HttpGet]
        [Route("nextstep")]
        public ActionResult NextStep(string purchaseId)
        {
            var purchase = purchaseService.GetOne(purchaseId);
            
            //GOTO
            return View("NextStep");
        }
    }
}