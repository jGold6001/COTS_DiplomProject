using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class CinemaDTOMapper : GeneralMapper<Cinema, CinemaDTO>
    {
        public CinemaDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cinema, CinemaDTO>()));
        }

        public override IEnumerable<CinemaDTO> MapToCollectionObjects(IEnumerable<Cinema> collectValues)
        {
            return Mapper.Map<IEnumerable<Cinema>, IEnumerable<CinemaDTO>>(collectValues);
        }

        public override CinemaDTO MapToObject(Cinema value)
        {
            return Mapper.Map<Cinema, CinemaDTO>(value);
        }
    }
}
