using COTS.WEBAPI.Utils.MapperManager;
using COTS.WEBAPI.Utils.MapperManager.DTOMappers;
using COTS.WEBAPI.Utils.MapperManager.ViewModelMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager
{
    public class MapperUnitOfWork
    {
        MovieShortViewModelMapper movieShortViewModelMapper;
        MovieFullViewModelMapper movieFullViewModelMapper;
        CinemaViewModelMapper cinemaViewModelMapper;
        CityViewModelMapper cityViewModelMapper;
        PurchaseDTOMapper purchaseDTOMapper;
        PurchaseViewModelMapper purchaseViewModelMapper;
        ClientDetailsViewModelMapper clientDetailsViewModelMapper;
        PurchaseClientDetailsDTOMapper purchaseClientDetailsDTOMapper;
        SeanceViewModelMapper seanceViewModelMapper;
        TicketViewModelMapper ticketViewModelMapper;
        TicketDTOMapper ticketDTOMapper;


        public MovieShortViewModelMapper MovieShortViewModelMapper
        {
            get
            {
                if (movieShortViewModelMapper == null)
                    movieShortViewModelMapper = new MovieShortViewModelMapper();
                return movieShortViewModelMapper;
            }
        }

        public MovieFullViewModelMapper MovieFullViewModelMapper
        {
            get
            {
                if (movieFullViewModelMapper == null)
                    movieFullViewModelMapper = new MovieFullViewModelMapper();
                return movieFullViewModelMapper;
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
                    purchaseDTOMapper = new PurchaseDTOMapper(TicketDTOMapper);
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

        public ClientDetailsViewModelMapper ClientDetailsViewModelMapper
        {
            get
            {
                if (clientDetailsViewModelMapper == null)
                    clientDetailsViewModelMapper = new ClientDetailsViewModelMapper();
                return clientDetailsViewModelMapper;
            }
        }

        public PurchaseClientDetailsDTOMapper PurchaseClientDetailsDTOMapper
        {
            get
            {
                if (purchaseClientDetailsDTOMapper == null)
                    purchaseClientDetailsDTOMapper = new PurchaseClientDetailsDTOMapper();
                return purchaseClientDetailsDTOMapper;
            }
        }

    }
}