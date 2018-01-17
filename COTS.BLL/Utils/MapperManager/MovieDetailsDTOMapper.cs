using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Utils.MapperManager
{
    public class MovieDetailsDTOMapper : GeneralMapper<MovieDetails, MovieDetailsDTO>
    {
        public MovieDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDetails, MovieDetailsDTO>()));
        }

        public override IEnumerable<MovieDetailsDTO> MapToCollectionObjects(IEnumerable<MovieDetails> collectValues)
        {
            return Mapper.Map<IEnumerable<MovieDetails>, IEnumerable<MovieDetailsDTO>>(collectValues);
        }

        public override MovieDetailsDTO MapToObject(MovieDetails value)
        {
            return Mapper.Map<MovieDetails, MovieDetailsDTO>(value);
        }
    }
}
