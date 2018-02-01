using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class EnterpriseDTOMapper : GeneralMapper<Enterprise, EnterpriseDTO>
    {
        public EnterpriseDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Enterprise, EnterpriseDTO>()));
        }

        public override IEnumerable<EnterpriseDTO> MapToCollectionObjects(IEnumerable<Enterprise> collectValues)
        {
            return Mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseDTO>>(collectValues); 
        }

        public override EnterpriseDTO MapToObject(Enterprise value)
        {
            return Mapper.Map<Enterprise, EnterpriseDTO>(value);
        }
    }
}
