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
    public class MovieViewModelMapper : GeneralMapper<MovieDTO, MovieViewModel>
    {
        public MovieViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()
               .ForMember("DateIssue", opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
            ));
        }

        public override IEnumerable<MovieViewModel> MapToCollectionObjects(IEnumerable<MovieDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(collectValues);
        }

        public override MovieViewModel MapToObject(MovieDTO value)
        {
            return Mapper.Map<MovieDTO, MovieViewModel>(value);
        }
    }
}