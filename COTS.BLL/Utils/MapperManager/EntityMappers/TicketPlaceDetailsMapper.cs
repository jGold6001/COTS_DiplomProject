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
    public class TicketPlaceDetailsMapper : GeneralMapper<TicketPlaceDetailsDTO, Place>
    {
        public TicketPlaceDetailsMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketPlaceDetailsDTO, Place>()));
        }
        public override IEnumerable<Place> MapToCollectionObjects(IEnumerable<TicketPlaceDetailsDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketPlaceDetailsDTO>, IEnumerable<Place>>(collectValues);
        }

        public override Place MapToObject(TicketPlaceDetailsDTO value)
        {
            return Mapper.Map<TicketPlaceDetailsDTO, Place>(value);
        }
    }
}
