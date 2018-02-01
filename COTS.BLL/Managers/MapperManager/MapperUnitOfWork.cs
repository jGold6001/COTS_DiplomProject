using COTS.BLL.Managers.MapperManager.DTOMappers;
using COTS.BLL.Managers.MapperManager.EntityMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.BLL.Managers.MapperManager
{
    public class MapperUnitOfWork
    {
        MovieDetailsDTOMapper movieDetailsDTOMapper;
        MovieDTOMapper movieDTOMapper;
        CinemaDTOMapper cinemaDTOMapper;
        CityDTOMapper cityDTOMapper;
        SeanceDTOMapper seanceDTOMapper;
        TicketDTOMapper ticketDTOMapper;
        PlaceDTOMapper placeDTOMapper;
        PurchaseDTOMapper purchaseDTOMapper;
        CustomerDTOMapper customerDTOMapper;
        TariffDTOMapper tariffDTOMapper;
        HallDTOMapper hallDTOMapper;
        SectorDTOMapper sectorDTOMapper;
        TechnologyDTOMapper technologyDTOMapper;
        EnterpriseDTOMapper enterpriseDTOMapper;

        TicketMapper ticketMapper;
        PlaceMapper placeMapper;
        PurchaseMapper purchaseMapper;
        CustomerMapper customerMapper;

        
        

        public MovieDetailsDTOMapper MovieDetailsDTOMapper
        {
            get
            {
                if (movieDetailsDTOMapper == null)
                    movieDetailsDTOMapper = new MovieDetailsDTOMapper();
                return movieDetailsDTOMapper;
            }
        }

        public MovieDTOMapper MovieDTOMapper
        {
            get
            {
                if (movieDTOMapper == null)
                    movieDTOMapper = new MovieDTOMapper();
                return movieDTOMapper;
            }
        }

        public CinemaDTOMapper CinemaDTOMapper
        {
            get
            {
                if (cinemaDTOMapper == null)
                    cinemaDTOMapper = new CinemaDTOMapper();
                return cinemaDTOMapper;
            }
        }

        public CityDTOMapper CityDTOMapper
        {
            get
            {
                if (cityDTOMapper == null)
                    cityDTOMapper = new CityDTOMapper();
                return cityDTOMapper;
            }
        }

        public SeanceDTOMapper SeanceDTOMapper
        {
            get
            {
                if (seanceDTOMapper == null)
                    seanceDTOMapper = new SeanceDTOMapper(MovieDTOMapper, HallDTOMapper);
                return seanceDTOMapper;
            }
        }

        public TicketDTOMapper TicketDTOMapper
        {
            get
            {
                if (ticketDTOMapper == null)
                    ticketDTOMapper = new TicketDTOMapper(SeanceDTOMapper, TariffDTOMapper);
                return ticketDTOMapper;
                        
            }
        }

        public SectorDTOMapper SectorDTOMapper
        {
            get
            {
                if (sectorDTOMapper == null)
                    sectorDTOMapper = new SectorDTOMapper();
                return sectorDTOMapper;
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

        public PurchaseDTOMapper PurchaseDTOMapper
        {
            get
            {
                if (purchaseDTOMapper == null)
                    purchaseDTOMapper = new PurchaseDTOMapper();
                return purchaseDTOMapper;
            }
        }

        public CustomerDTOMapper CustomerDTOMapper
        {
            get
            {
                if (customerDTOMapper == null)
                    customerDTOMapper = new CustomerDTOMapper();
                return customerDTOMapper;
            }
        }


        public TicketMapper TicketMapper
        {
            get
            {
                if (ticketMapper == null)
                    ticketMapper = new TicketMapper();
                return ticketMapper;
            }
        }

        public PlaceMapper PlaceMapper
        {
            get
            {
                if (placeMapper == null)
                    placeMapper = new PlaceMapper();
                return placeMapper;
            }
        }

        public PurchaseMapper PurchaseMapper
        {
            get
            {
                if (purchaseMapper == null)
                    purchaseMapper = new PurchaseMapper();
                return purchaseMapper;
            }
        }

        public CustomerMapper CustomerMapper
        {
            get
            {
                if (customerMapper == null)
                    customerMapper = new CustomerMapper();
                return customerMapper;
            }
        }

        public TariffDTOMapper TariffDTOMapper
        {
            get
            {
                if (tariffDTOMapper == null)
                    tariffDTOMapper = new TariffDTOMapper();
                return tariffDTOMapper;
            }
        }

        public HallDTOMapper HallDTOMapper
        {
            get
            {
                if (hallDTOMapper == null)
                    hallDTOMapper = new HallDTOMapper();
                return hallDTOMapper;
            }
        }

        public TechnologyDTOMapper TechnologyDTOMapper
        {
            get
            {
                if (technologyDTOMapper == null)
                    technologyDTOMapper = new TechnologyDTOMapper();
                return technologyDTOMapper;
            }
        }

        public EnterpriseDTOMapper EnterpriseDTOMapper
        {
            get
            {
                if (enterpriseDTOMapper == null)
                    enterpriseDTOMapper = new EnterpriseDTOMapper();
                return enterpriseDTOMapper;
            }
        }

    }
}