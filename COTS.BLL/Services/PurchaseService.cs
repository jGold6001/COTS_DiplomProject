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
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        
        ITicketService ticketService;
        IPurchaseClientDetailsService purchaseClientDetailsService;

        MapperUnitOfWork mapperUnitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
          
            ticketService = new TicketService(unitOfWork);
            purchaseClientDetailsService = new PurchaseClientDetailsService(unitOfWork);
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

            var purchase = mapperUnitOfWork.PurchaseMapper.MapToObject(purchaseDTO);
            var client = mapperUnitOfWork.PurchaseClientDetailsesMapper.MapToObject(purchaseDTO.PurchaseClientDetailsDTO);
            UnitOfWork.PurchaseClientDetailses.AddOrUpdate(client);
            UnitOfWork.Purchases.AddOrUpdate(purchase);
            UnitOfWork.Save();
        }


        private IEnumerable<PurchaseDTO> AttachObjetcsToDTOList(IEnumerable<Purchase> purchases)
        {
            var purchasesDTOs = mapperUnitOfWork.PurchaseDTOMapper.MapToCollectionObjects(purchases);
            foreach (var item in purchasesDTOs)
            {
                item.PurchaseClientDetailsDTO = purchaseClientDetailsService.GetOne(item.Id);
                item.TicketsDTOs = ticketService.GetByPurchase(item.Id);
            }
               
            return purchasesDTOs;
        }

        private PurchaseDTO AttachObjetcsToDTO(Purchase purchase)
        {
            var purchaseDTO = mapperUnitOfWork.PurchaseDTOMapper.MapToObject(purchase);
            var clientDTO = purchaseClientDetailsService.GetOne(purchaseDTO.Id);
            var ticketsDTOs = ticketService.GetByPurchase(purchaseDTO.Id);

            purchaseDTO.PurchaseClientDetailsDTO = clientDTO;
            purchaseDTO.TicketsDTOs = ticketsDTOs;
            return purchaseDTO;
        }

    }
}
