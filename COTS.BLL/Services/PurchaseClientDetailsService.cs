using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class PurchaseClientDetailsService : IPurchaseClientDetailsService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public PurchaseClientDetailsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();

        }

        public void AddOrUpdate(PurchaseClientDetailsDTO purchaseClientDetailsDTO)
        {
            var purchaseClientDetails = mapperUnitOfWork.PurchaseClientDetailsesMapper.MapToObject(purchaseClientDetailsDTO);
            UnitOfWork.PurchaseClientDetailses.AddOrUpdate(purchaseClientDetails);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseClientDetailsDTO> GetAll()
        {
            return mapperUnitOfWork.PurchaseClientDetailsDTOMapper.MapToCollectionObjects(UnitOfWork.PurchaseClientDetailses.GetAll());
        }

        public PurchaseClientDetailsDTO GetOne(string id)
        {
            return mapperUnitOfWork.PurchaseClientDetailsDTOMapper.MapToObject(UnitOfWork.PurchaseClientDetailses.Get(id));
        }
    }
}
