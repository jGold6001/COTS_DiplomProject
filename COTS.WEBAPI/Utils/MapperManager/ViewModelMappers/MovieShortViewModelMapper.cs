using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class MovieShortViewModelMapper : GeneralMapper<MovieDTO, MovieShortViewModel>
    {
        public MovieShortViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieShortViewModel>()
               .ForMember("DateIssue", opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
            ));
        }

        public override IEnumerable<MovieShortViewModel> MapToCollectionObjects(IEnumerable<MovieDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieShortViewModel>>(collectValues);
        }

        public override MovieShortViewModel MapToObject(MovieDTO value)
        {
            return Mapper.Map<MovieDTO, MovieShortViewModel>(value);
        }
    }
}