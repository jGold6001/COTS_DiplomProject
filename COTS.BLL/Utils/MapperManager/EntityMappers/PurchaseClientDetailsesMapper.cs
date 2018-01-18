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
    public class PurchaseClientDetailsesMapper : GeneralMapper<PurchaseClientDetailsDTO, PurchaseClientDetails>
    {
        public PurchaseClientDetailsesMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DTO.PurchaseClientDetailsDTO, PurchaseClientDetails>()));
        }

        public override IEnumerable<PurchaseClientDetails> MapToCollectionObjects(IEnumerable<PurchaseClientDetailsDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PurchaseClientDetailsDTO>, IEnumerable<PurchaseClientDetails>>(collectValues);
        }

        public override PurchaseClientDetails MapToObject(PurchaseClientDetailsDTO value)
        {
            return Mapper.Map<PurchaseClientDetailsDTO, PurchaseClientDetails>(value);
        }
    }
}
