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
using COTS.BLL.Infrastructure;

namespace COTS.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper, mapperReverse;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Purchase, PurchaseDTO>()));
            mapperReverse = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, Purchase>()));
        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            var purchase = UnitOfWork.Purchases.Get(id);
            UnitOfWork.Purchases.Delete(purchase);
            UnitOfWork.Save();
        }

        public IEnumerable<PurchaseDTO> GetAll()
        {
            var purchases = UnitOfWork.Purchases.GetAll();
            if (purchases.Count() == 0)
                throw new ValidationException("Purchases table is empty", "");

            return mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseDTO>>(purchases);
        }

        public PurchaseDTO GetOne(string id)
        {
            if (id == null)
                throw new ValidationException("'id' not set", "");

            return mapper.Map<Purchase, PurchaseDTO>(UnitOfWork.Purchases.Get(id));
        }

        public void AddOrUpdate(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                throw new ValidationException("PurchaseDTO not set", "");

            var purchase = mapperReverse.Map<PurchaseDTO, Purchase>(purchaseDTO);
            UnitOfWork.Purchases.AddOrUpdate(purchase);
            UnitOfWork.Save();
        }
    }
}
