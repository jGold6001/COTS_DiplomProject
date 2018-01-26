using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class SeanceViewModelMapper : GeneralMapper<SeanceDTO, SeanceViewModel>
    {
        public SeanceViewModelMapper(HallViewModelMapper hallViewModelMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
              .ForMember(d => d.DateSeance, opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
              .ForMember(d => d.TimeBegin, opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
              .ForMember(d => d.HallViewModel, opt => opt.MapFrom(src => hallViewModelMapper.MapToObject(src.HallDTO)))
              .ForMember(d => d.MovieShortViewModel, opt => opt.MapFrom(src => src.MovieDTO))
            ));
        }
       

        public override IEnumerable<SeanceViewModel> MapToCollectionObjects(IEnumerable<SeanceDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<SeanceDTO>,IEnumerable<SeanceViewModel>>(collectValues);
        }

        public override SeanceViewModel MapToObject(SeanceDTO value)
        {
            return Mapper.Map<SeanceDTO, SeanceViewModel>(value);
        }
    }
}