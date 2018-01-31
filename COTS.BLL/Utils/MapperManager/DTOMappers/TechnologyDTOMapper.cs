using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Utils.MapperManager.DTOMappers
{
    public class TechnologyDTOMapper : GeneralMapper<Technology, TechnologyDTO>
    {
        public TechnologyDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Technology, TechnologyDTO>()));
        }

        public override IEnumerable<TechnologyDTO> MapToCollectionObjects(IEnumerable<Technology> collectValues)
        {
            return Mapper.Map<IEnumerable<Technology>, IEnumerable<TechnologyDTO>>(collectValues);
        }

        public override TechnologyDTO MapToObject(Technology value)
        {
            return Mapper.Map<Technology, TechnologyDTO>(value);
        }
    }
}
