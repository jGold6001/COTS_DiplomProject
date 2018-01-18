using COTS.BLL.Utils.MapperManager.DTOMappers;
using COTS.BLL.Utils.MapperManager.EntityMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.BLL.Utils.MapperManager
{
    public class MapperUnitOfWork
    {
        MovieDetailsDTOMapper movieDetailsDTOMapper;
        MovieDTOMapper movieDTOMapper;
        CinemaDTOMapper cinemaDTOMapper;
        CityDTOMapper cityDTOMapper;
        SeanceDTOMapper seanceDTOMapper;
        TicketDTOMapper ticketDTOMapper;
        TicketPlaceDetailsDTOMapper ticketPlaceDetailsDTOMapper;
        PurchaseDTOMapper purchaseDTOMapper;
        PurchaseClientDetailsDTOMapper purchaseClientDetailsDTOMapper;

        TicketMapper ticketMapper;
        TicketPlaceDetailsMapper ticketPlaceDetailsMapper;
        PurchaseMapper purchaseMapper;
        PurchaseClientDetailsesMapper purchaseClientDetailsesMapper;
        

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
                    seanceDTOMapper = new SeanceDTOMapper(MovieDTOMapper);
                return seanceDTOMapper;
            }
        }

        public TicketDTOMapper TicketDTOMapper
        {
            get
            {
                if (ticketDTOMapper == null)
                    ticketDTOMapper = new TicketDTOMapper(SeanceDTOMapper);
                return ticketDTOMapper;
                        
            }
        }

        public TicketPlaceDetailsDTOMapper TicketPlaceDetailsDTOMapper
        {
            get
            {
                if (ticketPlaceDetailsDTOMapper == null)
                    ticketPlaceDetailsDTOMapper = new TicketPlaceDetailsDTOMapper();
                return ticketPlaceDetailsDTOMapper;
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

        public PurchaseClientDetailsDTOMapper PurchaseClientDetailsDTOMapper
        {
            get
            {
                if (purchaseClientDetailsDTOMapper == null)
                    purchaseClientDetailsDTOMapper = new PurchaseClientDetailsDTOMapper();
                return purchaseClientDetailsDTOMapper;
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

        public TicketPlaceDetailsMapper TicketPlaceDetailsMapper
        {
            get
            {
                if (ticketPlaceDetailsMapper == null)
                    ticketPlaceDetailsMapper = new TicketPlaceDetailsMapper();
                return ticketPlaceDetailsMapper;
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

        public PurchaseClientDetailsesMapper PurchaseClientDetailsesMapper
        {
            get
            {
                if (purchaseClientDetailsesMapper == null)
                    purchaseClientDetailsesMapper = new PurchaseClientDetailsesMapper();
                return purchaseClientDetailsesMapper;
            }
        }

    }
}