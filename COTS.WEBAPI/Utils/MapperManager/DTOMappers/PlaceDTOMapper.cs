using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class PlaceDTOMapper : GeneralMapper<PlaceViewModel, PlaceDTO>
    {
        public PlaceDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PlaceViewModel, PlaceDTO>()));
        }

        public override IEnumerable<PlaceDTO> MapToCollectionObjects(IEnumerable<PlaceViewModel> collectValues)
        {
            return Mapper.Map<IEnumerable<PlaceViewModel>, IEnumerable<PlaceDTO>>(collectValues);
        }

        public override PlaceDTO MapToObject(PlaceViewModel value)
        {
            return Mapper.Map<PlaceViewModel, PlaceDTO>(value);
        }
    }
}