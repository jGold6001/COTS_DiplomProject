using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class MovieFullViewModelMapper : GeneralMapper<MovieDTO, MovieFullViewModel>
    {
        public MovieFullViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieFullViewModel>()
                .ForMember(d => d.DateIssue, opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
                .ForMember(d => d.Genre, opt => opt.MapFrom(src => src.MovieDetailsDTO.Genre))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.MovieDetailsDTO.Description))
                .ForMember(d => d.Director, opt => opt.MapFrom(src => src.MovieDetailsDTO.Director))
                .ForMember(d => d.Actors, opt => opt.MapFrom(src => src.MovieDetailsDTO.Actors))
                .ForMember(d => d.AgeCategory, opt => opt.MapFrom(src => src.MovieDetailsDTO.AgeCategory))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.MovieDetailsDTO.Country))
                .ForMember(d => d.Duration, opt => opt.MapFrom(src => src.MovieDetailsDTO.Duration))
                .ForMember(d => d.TrailerUrl, opt => opt.MapFrom(src => src.MovieDetailsDTO.TrailerUrl))
                .ForMember(d => d.Year, opt => opt.MapFrom(src => src.MovieDetailsDTO.Year))
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