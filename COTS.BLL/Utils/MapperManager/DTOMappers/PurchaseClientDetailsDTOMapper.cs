using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Utils.MapperManager.DTOMappers
{

    public class PurchaseClientDetailsDTOMapper : GeneralMapper<PurchaseClientDetails, PurchaseClientDetailsDTO>
    {
        public PurchaseClientDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseClientDetails, PurchaseClientDetailsDTO>()));
        }

        public override IEnumerable<PurchaseClientDetailsDTO> MapToCollectionObjects(IEnumerable<PurchaseClientDetails> collectValues)
        {
            return Mapper.Map<IEnumerable<PurchaseClientDetails>, IEnumerable<PurchaseClientDetailsDTO>>(collectValues);
        }

        public override PurchaseClientDetailsDTO MapToObject(PurchaseClientDetails value)
        {
            return Mapper.Map<PurchaseClientDetails, PurchaseClientDetailsDTO>(value);
        }
    }
}
