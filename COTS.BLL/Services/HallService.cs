using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Utils.MapperManager;
using COTS.BLL.Interfaces;

namespace COTS.BLL.Services
{
    public class HallService : IHallService
    {
        IUnitOfWork UnitOfWork { get; set; }
        ICinemaService cinemaService;
        MapperUnitOfWork mapperUnitOfWork;

        public HallService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            cinemaService = new CinemaService(UnitOfWork);
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public HallDTO GetOne(long? id)
        {
            var hallDTO = AttachObjetcToDTO(UnitOfWork.Halls.Get(id));
            return hallDTO;
        }

        private HallDTO AttachObjetcToDTO(Hall hall)
        {
            var hallDTO = mapperUnitOfWork.HallDTOMapper.MapToObject(hall);
            var cinemaDTO = cinemaService.GetOne(hall.CinemaId);
            hallDTO.CinemaDTO = cinemaDTO;
            return hallDTO;
        }
    }
}
