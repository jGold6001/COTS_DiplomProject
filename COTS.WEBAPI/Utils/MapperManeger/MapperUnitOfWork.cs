using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManeger
{
    public class MapperUnitOfWork
    {
        PurchaseDTOMapper purchaseDTOMapper;
        PurchaseViewModelMapper purchaseViewModelMapper;
        SeanceViewModelMapper seanceViewModelMapper;
        TicketViewModelMapper ticketViewModelMapper;
        TicketDTOMapper ticketDTOMapper;

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
                    ticketViewModelMapper = new TicketViewModelMapper(this.seanceViewModelMapper);
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
                    purchaseViewModelMapper = new PurchaseViewModelMapper(ticketViewModelMapper);
                return purchaseViewModelMapper;
            }
        }



    }
}