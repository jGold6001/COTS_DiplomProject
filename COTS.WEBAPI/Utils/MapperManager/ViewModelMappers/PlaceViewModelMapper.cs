using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class PlaceViewModelMapper : GeneralMapper<PlaceDTO, PlaceViewModel>
    {
        public PlaceViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()));
        }

        public override IEnumerable<PlaceViewModel> MapToCollectionObjects(IEnumerable<PlaceDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PlaceDTO>, IEnumerable<PlaceViewModel>>(collectValues);
        }

        public override PlaceViewModel MapToObject(PlaceDTO value)
        {
            return Mapper.Map<PlaceDTO, PlaceViewModel>(value);
        }
    }
}