using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class MovieDTOMapper : GeneralMapper<Movie, MovieDTO>
    {
        public MovieDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()
                .ForMember(m => m.MovieDetailsDTO, opt => opt.MapFrom(src => src.MovieDetails))
            ));
        }

        public override IEnumerable<MovieDTO> MapToCollectionObjects(IEnumerable<Movie> collectValues)
        {
            return Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(collectValues);
        }

        public override MovieDTO MapToObject(Movie value)
        {
            return Mapper.Map<Movie, MovieDTO>(value);
        }
    }
}
