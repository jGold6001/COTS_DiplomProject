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
    public class SectorDTOMapper : GeneralMapper<Sector, SectorDTO>
    {
        public SectorDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Sector, SectorDTO>()));
        }

        public override IEnumerable<SectorDTO> MapToCollectionObjects(IEnumerable<Sector> collectValues)
        {
            return Mapper.Map<IEnumerable<Sector>, IEnumerable<SectorDTO>>(collectValues);
        }

        public override SectorDTO MapToObject(Sector value)
        {
            return Mapper.Map<Sector, SectorDTO>(value);
        }
    }
}
