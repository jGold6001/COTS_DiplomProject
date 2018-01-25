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
        MapperUnitOfWork mapperUnitOfWork;

        public HallService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public HallDTO GetOne(long? id)
        {
            return mapperUnitOfWork.HallDTOMapper.MapToObject(UnitOfWork.Halls.Get(id));
        }
    }
}
