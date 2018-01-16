using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManeger
{
    public class SeanceViewModelMapper : GeneralMapper<SeanceDTO, SeanceViewModel>
    {
        public SeanceViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
              .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
              .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
              .ForMember("CinemaViewModel", opt => opt.MapFrom(src => src.CinemaDTO))
              .ForMember("MovieViewModel", opt => opt.MapFrom(src => src.MovieDTO))
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