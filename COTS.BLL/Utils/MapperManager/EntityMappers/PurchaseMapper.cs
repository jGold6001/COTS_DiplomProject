using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Utils.MapperManager.EntityMappers
{
    public class PurchaseMapper : GeneralMapper<PurchaseDTO, Purchase>
    {
        public PurchaseMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, Purchase>()));
        }

        public override IEnumerable<Purchase> MapToCollectionObjects(IEnumerable<PurchaseDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PurchaseDTO>, IEnumerable<Purchase>>(collectValues);
        }

        public override Purchase MapToObject(PurchaseDTO value)
        {
            return Mapper.Map<PurchaseDTO, Purchase>(value);
        }
    }
}
