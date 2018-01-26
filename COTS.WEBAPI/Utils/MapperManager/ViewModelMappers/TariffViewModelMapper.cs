using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class TariffViewModelMapper : GeneralMapper<TariffDTO, TariffViewModel>
    {
        public TariffViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TariffDTO, TariffViewModel>()));
        }
        public override IEnumerable<TariffViewModel> MapToCollectionObjects(IEnumerable<TariffDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TariffDTO>, IEnumerable<TariffViewModel>>(collectValues);
        }

        public override TariffViewModel MapToObject(TariffDTO value)
        {
            return Mapper.Map<TariffDTO, TariffViewModel>(value);
        }
    }
}