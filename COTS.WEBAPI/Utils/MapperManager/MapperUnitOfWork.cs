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
        CustomerViewModelMapper clientDetailsViewModelMapper;
        CustomerDTOMapper  customerDTOMapper;
        SeanceViewModelMapper seanceViewModelMapper;
        TicketViewModelMapper ticketViewModelMapper;
        TariffViewModelMapper tariffViewModelMapper;
        HallViewModelMapper hallViewModelMapper;
        PlaceViewModelMapper placeViewModelMapper;
        TechnologyViewModelMapper technologyViewModelMapper;
        EnterpriseViewModelMapper enterpriseViewModelMapper;
        SectorViewModelMapper sectorViewModelMapper;

        TicketDTOMapper ticketDTOMapper;
        PlaceDTOMapper placeDTOMapper;

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
                    seanceViewModelMapper = new SeanceViewModelMapper(HallViewModelMapper, TariffViewModelMapper);
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

        public TariffViewModelMapper TariffViewModelMapper
        {
            get
            {
                if (tariffViewModelMapper == null)
                    tariffViewModelMapper = new TariffViewModelMapper();
                return tariffViewModelMapper;
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

        public PlaceViewModelMapper PlaceViewModelMapper
        {
            get
            {
                if (placeViewModelMapper == null)
                    placeViewModelMapper = new PlaceViewModelMapper();
                return placeViewModelMapper;
            }
        }

        public PlaceDTOMapper PlaceDTOMapper
        {
            get
            {
                if (placeDTOMapper == null)
                    placeDTOMapper = new PlaceDTOMapper();
                return placeDTOMapper;
            }
        }

        public CustomerViewModelMapper ClientDetailsViewModelMapper
        {
            get
            {
                if (clientDetailsViewModelMapper == null)
                    clientDetailsViewModelMapper = new CustomerViewModelMapper();
                return clientDetailsViewModelMapper;
            }
        }

        public CustomerDTOMapper  CustomerDTOMapper
        {
            get
            {
                if ( customerDTOMapper == null)
                     customerDTOMapper = new CustomerDTOMapper();
                return  customerDTOMapper;
            }
        }

        public HallViewModelMapper HallViewModelMapper
        {
            get
            {
                if (hallViewModelMapper == null)
                    hallViewModelMapper = new HallViewModelMapper();
                return hallViewModelMapper;
            }
        }

        public TechnologyViewModelMapper TechnologyViewModelMapper
        {
            get
            {
                if (technologyViewModelMapper == null)
                    technologyViewModelMapper = new TechnologyViewModelMapper();
                return technologyViewModelMapper;
            }
        }


        public EnterpriseViewModelMapper EnterpriseViewModelMapper
        {
            get
            {
                if (enterpriseViewModelMapper == null)
                    enterpriseViewModelMapper = new EnterpriseViewModelMapper();
                return enterpriseViewModelMapper;
            }
        }

        public SectorViewModelMapper SectorViewModelMapper
        {
            get
            {
                if (sectorViewModelMapper == null)
                    sectorViewModelMapper = new SectorViewModelMapper();
                return sectorViewModelMapper;
            }
        }

    }
}