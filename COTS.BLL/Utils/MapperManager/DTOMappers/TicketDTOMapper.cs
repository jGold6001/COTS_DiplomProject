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
    public class TicketDTOMapper : GeneralMapper<Ticket, TicketDTO>
    {
        public TicketDTOMapper(SeanceDTOMapper seanceDTOMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()
                .ForMember(m => m.SeanceDTO, opt => opt.MapFrom(src => seanceDTOMapper.MapToObject(src.Seance)))
                .ForMember(m => m.TicketPlaceDetailsDTO, opt => opt.MapFrom(src => src.TicketPlaceDetails))
            ));
        }

        public override IEnumerable<TicketDTO> MapToCollectionObjects(IEnumerable<Ticket> collectValues)
        {
            return Mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(collectValues);
        }

        public override TicketDTO MapToObject(Ticket value)
        {
            return Mapper.Map<Ticket, TicketDTO>(value);
        }
    }
}
