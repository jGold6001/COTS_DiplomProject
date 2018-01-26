using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Utils.MapperManager.DTOMappers
{
    public class SeanceDTOMapper : GeneralMapper<Seance, SeanceDTO>
    {
        public SeanceDTOMapper(MovieDTOMapper movieDTOMapper, HallDTOMapper hallDTOMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Seance, SeanceDTO>()
                .ForMember(m => m.HallDTO, opt => opt.MapFrom(src => hallDTOMapper.MapToObject(src.Hall)))
                .ForMember(m => m.MovieDTO, opt => opt.MapFrom(src => movieDTOMapper.MapToObject(src.Movie)))
            ));
        }
        public override IEnumerable<SeanceDTO> MapToCollectionObjects(IEnumerable<Seance> collectValues)
        {
            return Mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(collectValues);
        }

        public override SeanceDTO MapToObject(Seance value)
        {
            return Mapper.Map<Seance, SeanceDTO>(value);
        }
    }
}
