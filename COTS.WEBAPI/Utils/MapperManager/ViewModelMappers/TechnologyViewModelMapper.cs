using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class TechnologyViewModelMapper : GeneralMapper<TechnologyDTO, TechnologyViewModel>
    {
        public TechnologyViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TechnologyDTO, TechnologyViewModel>()));
        }

        public override IEnumerable<TechnologyViewModel> MapToCollectionObjects(IEnumerable<TechnologyDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TechnologyDTO>, IEnumerable<TechnologyViewModel>>(collectValues);
        }

        public override TechnologyViewModel MapToObject(TechnologyDTO value)
        {
            return Mapper.Map<TechnologyDTO, TechnologyViewModel>(value);
        }
    }
}