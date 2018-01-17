using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Utils.MapperManager.EntityMappers
{
    public class TicketPlaceDetailsMapper : GeneralMapper<TicketPlaceDetailsDTO, TicketPlaceDetails>
    {
        public TicketPlaceDetailsMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketPlaceDetailsDTO, TicketPlaceDetails>()));
        }
        public override IEnumerable<TicketPlaceDetails> MapToCollectionObjects(IEnumerable<TicketPlaceDetailsDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketPlaceDetailsDTO>, IEnumerable<TicketPlaceDetails>>(collectValues);
        }

        public override TicketPlaceDetails MapToObject(TicketPlaceDetailsDTO value)
        {
            return Mapper.Map<TicketPlaceDetailsDTO, TicketPlaceDetails>(value);
        }
    }
}
