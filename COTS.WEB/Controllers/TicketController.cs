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

        IMapper mapper;

        public TicketController(ITicketService ticketService, ISeanceService seanceService, IMovieService movieService, ICinemaService cinemaService)
        {
            this.ticketService = ticketService;
            this.seanceService = seanceService;
            this.movieService = movieService;
            this.cinemaService = cinemaService;

            mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, TicketViewModel>()
                 .ForMember("Cinema", opt => opt.MapFrom(src => cinemaService.GetOne(seanceService.GetOne(src.SeanceId).CinemaId).Name))
                 .ForMember("Movie", opt => opt.MapFrom(src => movieService.GetOne(seanceService.GetOne(src.SeanceId).MovieId).Name))
            ));
        }

        [HttpPost]
        [Route("nextstep")]
        public ActionResult NextStep(IEnumerable<TicketViewModel> tickets)
        {          
            return View(tickets);
        }

        [HttpGet]
        public ActionResult NextStep()
        {
            return View();
        }
    }
}