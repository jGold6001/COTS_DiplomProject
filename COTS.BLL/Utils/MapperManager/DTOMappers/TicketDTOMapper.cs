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
        public TicketDTOMapper(SeanceDTOMapper seanceDTOMapper, TariffDTOMapper tariffDTOMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()
                .ForMember(d => d.SeanceDTO, opt => opt.MapFrom(src => seanceDTOMapper.MapToObject(src.Seance)))
                .ForMember(d => d.PlaceDTO, opt => opt.MapFrom(src => src.Place))
                .ForMember(d => d.TariffDTO, opt => opt.MapFrom(src => tariffDTOMapper.MapToObject(src.Tariff)))
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
