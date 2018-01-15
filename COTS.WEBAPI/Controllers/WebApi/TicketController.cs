using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Constants;
using COTS.WEBAPI.Models;
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

        ISeanceService seanceService;
        IMovieService movieService;
        ICinemaService cinemaService;

        IMapper mapperTicket, 
                mapperTicketReverse, 
                mapperPurchase, 
                mapperPurchaseReverce,
                mapperSeance,
                mapperMovie,
                mapperCinema;


        public TicketController()
        {

        }

        public TicketController(ITicketService ticketService, IPurchaseService purchaseService, ISeanceService seanceService, IMovieService movieService, ICinemaService cinemaService)
        {
            this.ticketService = ticketService;
            this.purchaseService = purchaseService;

            this.seanceService = seanceService;
            this.movieService = movieService;
            this.cinemaService = cinemaService;

           
            mapperMovie = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<MovieDTO, MovieViewModel>()));
            mapperCinema = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<CinemaDTO, CinemaViewModel>()));
            mapperSeance = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
                .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
                .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
                .ForMember("CinemaViewModel", opt => opt.MapFrom(src =>
                    mapperCinema.Map<CinemaDTO, CinemaViewModel>(cinemaService.GetOne(src.CinemaId)))
                )
                .ForMember("MovieViewModel", opt => opt.MapFrom(src =>
                    mapperMovie.Map<MovieDTO, MovieViewModel>(movieService.GetOne(src.MovieId)))
                )
           ));

            mapperTicket = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, TicketViewModel>()
                .ForMember("SeanceViewModel", opt => opt.MapFrom(src =>
                    mapperSeance.Map<SeanceDTO, SeanceViewModel>(seanceService.GetOne(src.SeanceId))
                )        
           )));

            mapperTicketReverse = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketViewModel, TicketDTO>()));
            mapperPurchaseReverce = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseViewModel, PurchaseDTO>()));
            mapperPurchase = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, PurchaseViewModel>()));
        }

        [Route("all")]
        public IEnumerable<TicketViewModel> GetAllTickets()
        {
            return mapperTicket.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(ticketService.GetAll());
        }

        [Route("all_purchases")]
        public IEnumerable<PurchaseViewModel> GetAll()
        {
            return mapperPurchase.Map<IEnumerable<PurchaseDTO>, IEnumerable<PurchaseViewModel>>(purchaseService.GetAll());
        }

        [HttpPost]
        [Route("save_in_db")]
        public void SaveInDb(PurchaseViewModel purchaseViewModel)
        {   
            purchaseService.AddOrUpdate(mapperPurchaseReverce.Map<PurchaseViewModel, PurchaseDTO>(purchaseViewModel));
            var tickets = purchaseViewModel.TicketViewModels;
            foreach (var item in tickets)
                ticketService.AddOrUpdate(mapperTicketReverse.Map<TicketViewModel, TicketDTO>(item));         
        }


        [Route("all_booking")]
        public IEnumerable<TicketViewModel> GetAllBookingTickets()
        {
            return mapperTicket.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(ticketService.GetByState(TicketStates.BOOKING));
        }

        [Route("by_purchase")]
        public IEnumerable<TicketViewModel> GetAllByPurchase()
        {
            return null;
        }

        [Route("get_purchase/{purchaseId}")]
        public PurchaseViewModel GetPurchase(string purchaseId)
        {
            var purchaseVM = mapperPurchase.Map<PurchaseDTO, PurchaseViewModel>(purchaseService.GetOne(purchaseId));
            var ticketsByPurchase = mapperTicket.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(ticketService.GetByPurchase(purchaseId));

            purchaseVM.TicketViewModels = ticketsByPurchase as List<TicketViewModel>;
            return  purchaseVM;
        }


    }
}
