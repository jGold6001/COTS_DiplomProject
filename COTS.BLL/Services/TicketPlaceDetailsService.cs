using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.BLL.Utils.MapperManager;
using COTS.DAL.Interfaces;

namespace COTS.BLL.Services
{
    public class TicketPlaceDetailsService : ITicketPlaceDetailsService
    {
        IUnitOfWork UnitOfWork { get; set; }

        MapperUnitOfWork mapperUnitOfWork;

        public TicketPlaceDetailsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(TicketPlaceDetailsDTO ticketPlaceDetailsDTO)
        {
            var ticketPlaceDetails = mapperUnitOfWork.TicketPlaceDetailsMapper.MapToObject(ticketPlaceDetailsDTO);
            UnitOfWork.TicketPlaceDetails.AddOrUpdate(ticketPlaceDetails);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketPlaceDetailsDTO> GetAll()
        {
            return mapperUnitOfWork.TicketPlaceDetailsDTOMapper.MapToCollectionObjects(UnitOfWork.TicketPlaceDetails.GetAll());
        }

        public TicketPlaceDetailsDTO GetOne(string id)
        {
            return mapperUnitOfWork.TicketPlaceDetailsDTOMapper.MapToObject(UnitOfWork.TicketPlaceDetails.Get(id));
        }
    }
}
