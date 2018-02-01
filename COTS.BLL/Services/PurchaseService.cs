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
using COTS.BLL.Managers.MapperManager;

namespace COTS.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        
        ITicketService ticketService;
        ICustomerService customerService;

        MapperUnitOfWork mapperUnitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
          
            ticketService = new TicketService(unitOfWork);
            customerService = new CustomerService(unitOfWork);
        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            //delete tickets by purchase
            var tickets = ticketService.GetByPurchase(id);
            if(tickets.Count() > 0)
            {
                foreach (var item in ticketService.GetByPurchase(id))
                    ticketService.Delete(item.Id);
            }         

            //delete customer
            var customer = customerService.GetOne(id);
            if(customer != null)
                customerService.Delete(id);

            //delete purchase
            UnitOfWork.Purchases.Delete(UnitOfWork.Purchases.Get(id));            
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

            if (purchaseDTO.CustomerDTO != null)
                customerService.AddOrUpdate(purchaseDTO.CustomerDTO);
                     
            var purchase = mapperUnitOfWork.PurchaseMapper.MapToObject(purchaseDTO);
            UnitOfWork.Purchases.AddOrUpdate(purchase);

            foreach (var item in purchaseDTO.TicketsDTOs)
                ticketService.AddOrUpdate(item);
           
        }


        private IEnumerable<PurchaseDTO> AttachObjetcsToDTOList(IEnumerable<Purchase> purchases)
        {
            var purchasesDTOs = mapperUnitOfWork.PurchaseDTOMapper.MapToCollectionObjects(purchases);
            foreach (var item in purchasesDTOs)
            {
                item.CustomerDTO = customerService.GetOne(item.Id);
                item.TicketsDTOs = ticketService.GetByPurchase(item.Id);
            }
               
            return purchasesDTOs;
        }

        private PurchaseDTO AttachObjetcsToDTO(Purchase purchase)
        {
            var purchaseDTO = mapperUnitOfWork.PurchaseDTOMapper.MapToObject(purchase);
            var customerDTO = customerService.GetOne(purchaseDTO.Id);

            var ticketsDTOs = ticketService.GetByPurchase(purchaseDTO.Id);

            purchaseDTO.CustomerDTO = customerDTO;
            purchaseDTO.TicketsDTOs = ticketsDTOs;
            return purchaseDTO;
        }

    }
}
