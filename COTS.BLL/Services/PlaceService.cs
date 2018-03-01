using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.BLL.Managers.MapperManager;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Managers.PlaceManager;

namespace COTS.BLL.Services
{
    public class PlaceService : IPlaceService
    {
        IUnitOfWork UnitOfWork { get; set; }
        PlaceRepository placeRepo;
        MapperUnitOfWork mapperUnitOfWork;
        ITicketService ticketService;

        public PlaceService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            placeRepo = UnitOfWork.Places as PlaceRepository;
            mapperUnitOfWork = new MapperUnitOfWork();       
        }

        public void AddOrUpdate(PlaceDTO placeDTO)
        {
            var place = mapperUnitOfWork.PlaceMapper.MapToObject(placeDTO);
            UnitOfWork.Places.AddOrUpdate(place);
        }

        public PlaceDTO GetOne(long? id)
        {
            return mapperUnitOfWork.PlaceDTOMapper.MapToObject(placeRepo.Get(id));
        }

        public IEnumerable<PlaceDTO> GetAllByCityCinemaHallAndSeance(string cityId, string cinemaId, string hallName, long seanceId)
        {
            ticketService = new TicketService(this.UnitOfWork);
            var placeDTOs = mapperUnitOfWork.PlaceDTOMapper.MapToCollectionObjects(placeRepo.GetAllByCityCinemaAndHall(cityId, cinemaId, hallName));
            var placeDTOsWithIsBusy = new List<PlaceDTO>();
            foreach (var item in placeDTOs)
                placeDTOsWithIsBusy.Add(PlaceDTOManager.AssignIsBusyTo(item, seanceId, ticketService));

            return placeDTOs;
        }

        public IEnumerable<PlaceDTO> GetAllBySeanceAndHall(long hallId, long seanceId)
        {
            ticketService = new TicketService(this.UnitOfWork);
            var placeDTOs = mapperUnitOfWork.PlaceDTOMapper.MapToCollectionObjects(placeRepo.GetAllByHall(hallId));
            var placeDTOsWithIsBusy = new List<PlaceDTO>();
            foreach (var item in placeDTOs)
                placeDTOsWithIsBusy.Add(PlaceDTOManager.AssignIsBusyTo(item, seanceId, ticketService));

            return placeDTOs;
        }
    }
}
