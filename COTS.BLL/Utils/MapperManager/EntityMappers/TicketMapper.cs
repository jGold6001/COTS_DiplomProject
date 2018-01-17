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
    public class TicketMapper : GeneralMapper<TicketDTO, Ticket>
    {
        public TicketMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()

            ));
        }
        public override IEnumerable<Ticket> MapToCollectionObjects(IEnumerable<TicketDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketDTO>, IEnumerable<Ticket>>(collectValues);
        }

        public override Ticket MapToObject(TicketDTO value)
        {
            return Mapper.Map<TicketDTO, Ticket>(value);
        }
    }
}
