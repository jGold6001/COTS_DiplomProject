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
    public class TicketPlaceDetailsDTOMapper : GeneralMapper<Place, TicketPlaceDetailsDTO>
    {
        public TicketPlaceDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Place, TicketPlaceDetailsDTO>()));
        }

        public override IEnumerable<TicketPlaceDetailsDTO> MapToCollectionObjects(IEnumerable<Place> collectValues)
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<TicketPlaceDetailsDTO>>(collectValues);
        }

        public override TicketPlaceDetailsDTO MapToObject(Place value)
        {
            return Mapper.Map<Place, TicketPlaceDetailsDTO>(value);
        }
    }
}
