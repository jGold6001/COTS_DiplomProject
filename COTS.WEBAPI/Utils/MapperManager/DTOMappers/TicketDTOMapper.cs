using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class TicketDTOMapper : GeneralMapper<TicketViewModel, TicketDTO>
    {
        public TicketDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketViewModel, TicketDTO>()
                .ForMember(d => d.TicketPlaceDetailsDTO, opt => opt.MapFrom(src => src.PlaceDetailsViewModel))
            ));
        }
        public override IEnumerable<TicketDTO> MapToCollectionObjects(IEnumerable<TicketViewModel> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketViewModel>, IEnumerable<TicketDTO>>(collectValues);
        }

        public override TicketDTO MapToObject(TicketViewModel value)
        {
            return Mapper.Map<TicketViewModel, TicketDTO>(value);
        }
    }
}
