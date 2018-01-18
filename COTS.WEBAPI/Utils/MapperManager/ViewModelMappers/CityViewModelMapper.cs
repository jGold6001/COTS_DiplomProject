using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class CityViewModelMapper : GeneralMapper<CityDTO, CityViewModel>
    {
        public CityViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()));
        }

        public override IEnumerable<CityViewModel> MapToCollectionObjects(IEnumerable<CityDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(collectValues);
        }

        public override CityViewModel MapToObject(CityDTO value)
        {
            return Mapper.Map<CityDTO, CityViewModel>(value);
        }
    }
}