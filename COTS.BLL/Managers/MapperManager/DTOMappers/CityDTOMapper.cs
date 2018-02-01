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
    public class CityDTOMapper : GeneralMapper<City, CityDTO>
    {
        public CityDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()));
        }
        public override IEnumerable<CityDTO> MapToCollectionObjects(IEnumerable<City> collectValues)
        {
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(collectValues);
        }

        public override CityDTO MapToObject(City value)
        {
            return Mapper.Map<City, CityDTO>(value);
        }
    }
}
