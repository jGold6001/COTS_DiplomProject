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
    public class TicketPlaceDetailsDTOMapper : GeneralMapper<TicketPlaceDetails, TicketPlaceDetailsDTO>
    {
        public TicketPlaceDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketPlaceDetails, TicketPlaceDetailsDTO>()));
        }

        public override IEnumerable<TicketPlaceDetailsDTO> MapToCollectionObjects(IEnumerable<TicketPlaceDetails> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketPlaceDetails>, IEnumerable<TicketPlaceDetailsDTO>>(collectValues);
        }

        public override TicketPlaceDetailsDTO MapToObject(TicketPlaceDetails value)
        {
            return Mapper.Map<TicketPlaceDetails, TicketPlaceDetailsDTO>(value);
        }
    }
}
