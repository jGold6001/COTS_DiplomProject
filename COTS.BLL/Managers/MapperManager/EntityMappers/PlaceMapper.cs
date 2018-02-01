using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Managers.MapperManager.EntityMappers
{
    public class PlaceMapper : GeneralMapper<PlaceDTO, Place>
    {
        public PlaceMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, Place>()));
        }
        public override IEnumerable<Place> MapToCollectionObjects(IEnumerable<PlaceDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PlaceDTO>, IEnumerable<Place>>(collectValues);
        }

        public override Place MapToObject(PlaceDTO value)
        {
            return Mapper.Map<PlaceDTO, Place>(value);
        }
    }
}
