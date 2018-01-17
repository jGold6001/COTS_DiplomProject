using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using AutoMapper;
using COTS.DAL.Interfaces;
using COTS.DAL.Entities;
using COTS.BLL.Utils;

namespace COTS.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        IMapper mapperPurchase, mapperPurchaseReverse;
        IMapper mapperClientDetails, mapperClientDetailsReverse;
        ITicketService ticketService;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;           
            mapperPurchase = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Purchase, PurchaseDTO>()));
            mapperPurchaseReverse = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, Purchase>()));

            mapperClientDetails = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseClientDetails, PurchaseClientDetailsDTO>()));
            mapperClientDetailsReverse = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseClientDetailsDTO, PurchaseClientDetails>()));

            ticketService = new TicketService(unitOfWork);
        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            var purchase = UnitOfWork.Purchases.Get(id);
            var client = UnitOfWork.PurchaseClientDetailses.Get(id);

            var tickets = ticketService.GetAll();
            foreach (var item in tickets)
                ticketService.Delete(item.Id);

            UnitOfWork.Purchases.Delete(purchase);
            UnitOfWork.PurchaseClientDetailses.Delete(client);
            UnitOfWork.Save();
        }

        public IEnumerable<PurchaseDTO> GetAll()
        {
            var purchases = UnitOfWork.Purchases.GetAll();
            if (purchases.Count() == 0)
                throw new ValidationException("Purchases table is empty", "");

            var purchasesDTOs = AttachObjetcsToDTOList(purchases);
            return purchasesDTOs;
        }

        public PurchaseDTO GetOne(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            var purchase = UnitOfWork.Purchases.Get(id);
            var purchaseDTO = AttachObjetcsToDTO(purchase);
            return purchaseDTO;
        }

        public void AddOrUpdate(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                throw new ValidationException("PurchaseDTO not set", "");

            var purchase = mapperPurchaseReverse.Map<PurchaseDTO, Purchase>(purchaseDTO);
            var client = mapperClientDetailsReverse.Map<PurchaseClientDetailsDTO, PurchaseClientDetails>(purchaseDTO.PurchaseClientDetailsDTO);
            UnitOfWork.PurchaseClientDetailses.AddOrUpdate(client);
            UnitOfWork.Purchases.AddOrUpdate(purchase);
            UnitOfWork.Save();
        }


        private List<PurchaseDTO> AttachObjetcsToDTOList(IEnumerable<Purchase> purchases)
        {
            var purchasesDTOs = mapperPurchase.Map<IEnumerable<Purchase>, IEnumerable<PurchaseDTO>>(purchases) as List<PurchaseDTO>;
            foreach (var item in purchasesDTOs)
            {
                item.PurchaseClientDetailsDTO = mapperClientDetails.Map<PurchaseClientDetails, PurchaseClientDetailsDTO>(UnitOfWork.PurchaseClientDetailses.Get(item.Id));
                item.TicketsDTOs = ticketService.GetByPurchase(item.Id) as List<TicketDTO>;
            }
               

            return purchasesDTOs;
        }

        private PurchaseDTO AttachObjetcsToDTO(Purchase purchase)
        {
            var purchaseDTO = mapperPurchase.Map<Purchase, PurchaseDTO>(purchase);
            var clientDTO = mapperClientDetails.Map<PurchaseClientDetails, PurchaseClientDetailsDTO>(UnitOfWork.PurchaseClientDetailses.Get(purchase.Id));
            var ticketsDTOs = ticketService.GetByPurchase(purchase.Id) as List<TicketDTO>;

            purchaseDTO.PurchaseClientDetailsDTO = clientDTO;
            purchaseDTO.TicketsDTOs = ticketsDTOs;
            return purchaseDTO;
        }

    }
}
