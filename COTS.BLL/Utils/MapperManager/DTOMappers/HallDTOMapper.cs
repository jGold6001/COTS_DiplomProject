using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Utils.MapperManager.DTOMappers
{
    public class HallDTOMapper : GeneralMapper<Hall, HallDTO>
    {
        public HallDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Hall, HallDTO>()
                .ForMember(d => d.CinemaDTO, opt => opt.MapFrom(src => src.Cinema))
            ));
        }
        public override IEnumerable<HallDTO> MapToCollectionObjects(IEnumerable<Hall> collectValues)
        {
            return Mapper.Map<IEnumerable<Hall>, IEnumerable<HallDTO>>(collectValues);
        }

        public override HallDTO MapToObject(Hall value)
        {
            return Mapper.Map<Hall, HallDTO>(value);
        }
    }
}
