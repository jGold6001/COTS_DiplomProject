using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class PlaceDTOMapper : GeneralMapper<Place, PlaceDTO>
    {
        public PlaceDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()));
        }

        public override IEnumerable<PlaceDTO> MapToCollectionObjects(IEnumerable<Place> collectValues)
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(collectValues);
        }

        public override PlaceDTO MapToObject(Place value)
        {
            return Mapper.Map<Place, PlaceDTO>(value);
        }
    }
}
