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
    public class MovieViewModelMapper : GeneralMapper<MovieDTO, MovieFullViewModel>
    {
        public MovieViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieFullViewModel>()
               .ForMember("DateIssue", opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
            ));
        }

        public override IEnumerable<MovieFullViewModel> MapToCollectionObjects(IEnumerable<MovieDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieFullViewModel>>(collectValues);
        }

        public override MovieFullViewModel MapToObject(MovieDTO value)
        {
            return Mapper.Map<MovieDTO, MovieFullViewModel>(value);
        }
    }
}