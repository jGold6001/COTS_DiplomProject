using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class HallViewModelMapper : GeneralMapper<HallDTO, HallViewModel>
    {
        public HallViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<HallDTO, HallViewModel>()
                .ForMember(d => d.CinemaViewModel, opt => opt.MapFrom(src => src.CinemaDTO))
            ));
        }

        public override IEnumerable<HallViewModel> MapToCollectionObjects(IEnumerable<HallDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<HallDTO>, IEnumerable<HallViewModel>>(collectValues);
        }

        public override HallViewModel MapToObject(HallDTO value)
        {
            return Mapper.Map<HallDTO, HallViewModel>(value);
        }
    }
}