using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEB.Models;
using COTS.WEB.Resources.Constants;
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

        IMapper mapper, mapperReverse, mapperPurchase, mapperPurchaseReverce;

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
            mapperPurchase = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseViewModel, PurchaseDTO>()));
            mapperPurchaseReverce = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, PurchaseViewModel>()));
        }

        [HttpPost]         
        public ActionResult SaveInDb(PurchaseViewModel purchaseViewModel)
        {         
            var purchaseDTO = mapperPurchase.Map<PurchaseViewModel, PurchaseDTO>(purchaseViewModel);
            purchaseService.AddOrUpdate(purchaseDTO);

            var tickets = purchaseViewModel.TicketViewModels;
            foreach (var item in tickets)
            {
                var ticket = mapperReverse.Map<TicketViewModel, TicketDTO>(item);
                ticket.PurchaseId = purchaseDTO.Id;
                ticket.Id = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-"));
                ticketService.AddOrUpdate(ticket);
            }
            return Content("Data are saving in DataBase!!!");
        }

        [HttpGet]
        [Route("nextstep")]
        public ActionResult NextStep(string purchaseId)
        {
            ViewData["PurchaseID"] = purchaseId;
            var tickets = ticketService.GetByPurchase(purchaseId);
            var ticketsVM = mapper.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(tickets);
            return View("NextStep", ticketsVM);
        }


        public JsonResult GetAll()
        {
            var ticketsDTO = ticketService.GetAll();
            if (ticketsDTO == null)
                return Json(null, JsonRequestBehavior.AllowGet);
          
            var tickets = mapper.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(ticketsDTO);
            return Json(tickets, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAllBooking()
        {     
            var ticketsDTO = ticketService.GetByState(TicketStates.BOOKING);       
            var tickets = mapper.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(ticketsDTO);
            return Json(tickets, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Ordering(string purchaseId)
        {
            var purchaseDTO = purchaseService.GetOne(purchaseId);
            var purchase = mapperPurchaseReverce.Map<PurchaseDTO, PurchaseViewModel>(purchaseDTO);
            return View(purchase);
        }

        [HttpPost]
        public ActionResult RemovePurchase(string purchaseId)
        {
            var tickets = ticketService.GetByPurchase(purchaseId);
            
            foreach (var item in tickets)
                ticketService.Delete(item.Id);

            purchaseService.Delete(purchaseId);
            return Content("Tickets remove from db");
        }

        [HttpPost]
        public ActionResult Payment(PurchaseViewModel purchaseViewModel)
        {
            var tickets = ticketService.GetByPurchase(purchaseViewModel.Id);

            foreach (var item in tickets)
            {
                item.State = TicketStates.SOLD;
                ticketService.AddOrUpdate(item);
            }

            var purchase = mapperPurchase.Map<PurchaseViewModel, PurchaseDTO>(purchaseViewModel);
            purchaseService.AddOrUpdate(purchase);
            return Content($"Ваш заказ: {purchaseViewModel.Id} успешно оформлен");
        }

    }
}