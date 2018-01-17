using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManeger
{
    public class MapperUnitOfWork
    {
        MovieViewModelMapper movieViewModelMapper;
        CinemaViewModelMapper cinemaViewModelMapper;
        CityViewModelMapper cityViewModelMapper;
        PurchaseDTOMapper purchaseDTOMapper;
        PurchaseViewModelMapper purchaseViewModelMapper;
        SeanceViewModelMapper seanceViewModelMapper;
        TicketViewModelMapper ticketViewModelMapper;
        TicketDTOMapper ticketDTOMapper;


        public MovieViewModelMapper MovieViewModelMapper
        {
            get
            {
                if (movieViewModelMapper == null)
                    movieViewModelMapper = new MovieViewModelMapper();
                return movieViewModelMapper;
            }
        }

        public CinemaViewModelMapper CinemaViewModelMapper
        {
            get
            {
                if (cinemaViewModelMapper == null)
                    cinemaViewModelMapper = new CinemaViewModelMapper();
                return cinemaViewModelMapper;
            }
        }

        public CityViewModelMapper CityViewModelMapper
        {
            get
            {
                if (cityViewModelMapper == null)
                    cityViewModelMapper = new CityViewModelMapper();
                return cityViewModelMapper;
            }
        }

        public SeanceViewModelMapper SeanceViewModelMapper
        {
            get
            {
                if (seanceViewModelMapper == null)
                    seanceViewModelMapper = new SeanceViewModelMapper();
                return seanceViewModelMapper;
            }
        }

        public TicketViewModelMapper TicketViewModelMapper
        {
            get
            {
                if (ticketViewModelMapper == null)
                    ticketViewModelMapper = new TicketViewModelMapper(SeanceViewModelMapper);
                return ticketViewModelMapper;
            }
        }

        public TicketDTOMapper TicketDTOMapper
        {
            get
            {
                if (ticketDTOMapper == null)
                    ticketDTOMapper = new TicketDTOMapper();
                return ticketDTOMapper;
            }
        }


        public PurchaseDTOMapper PurchaseDTOMapper
        {
            get
            {
                if (purchaseDTOMapper == null)
                    purchaseDTOMapper = new PurchaseDTOMapper();
                return purchaseDTOMapper;
            }
        }

        public PurchaseViewModelMapper PurchaseViewModelMapper
        {
            get
            {
                if (purchaseViewModelMapper == null)
                    purchaseViewModelMapper = new PurchaseViewModelMapper(TicketViewModelMapper);
                return purchaseViewModelMapper;
            }
        }



    }
}