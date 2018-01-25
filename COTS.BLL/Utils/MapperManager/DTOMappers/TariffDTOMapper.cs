using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Utils.MapperManager.DTOMappers
{
    public class TariffDTOMapper : GeneralMapper<Tariff, TariffDTO>
    {
        public TariffDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Tariff, TariffDTO>()));
        }

        public override IEnumerable<TariffDTO> MapToCollectionObjects(IEnumerable<Tariff> collectValues)
        {
            return Mapper.Map<IEnumerable<Tariff>, IEnumerable<TariffDTO>>(collectValues);
        }

        public override TariffDTO MapToObject(Tariff value)
        {
            return Mapper.Map<Tariff, TariffDTO>(value);
        }
    }
}
