using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class SectorViewModelMapper : GeneralMapper<SectorDTO, SectorViewModel>
    {
        public SectorViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SectorDTO, SectorViewModel>()));
        }

        public override IEnumerable<SectorViewModel> MapToCollectionObjects(IEnumerable<SectorDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<SectorDTO>, IEnumerable<SectorViewModel>>(collectValues);
        }

        public override SectorViewModel MapToObject(SectorDTO value)
        {
            return Mapper.Map<SectorDTO,SectorViewModel>(value);
        }
    }
}