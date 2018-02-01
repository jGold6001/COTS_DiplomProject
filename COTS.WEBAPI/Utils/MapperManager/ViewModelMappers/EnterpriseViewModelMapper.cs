using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class EnterpriseViewModelMapper : GeneralMapper<EnterpriseDTO, EnterpriseViewModel>
    {
        public EnterpriseViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<EnterpriseDTO, EnterpriseViewModel>()));
        }

        public override IEnumerable<EnterpriseViewModel> MapToCollectionObjects(IEnumerable<EnterpriseDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<EnterpriseDTO>, IEnumerable<EnterpriseViewModel>>(collectValues);
        }

        public override EnterpriseViewModel MapToObject(EnterpriseDTO value)
        {
            return Mapper.Map<EnterpriseDTO, EnterpriseViewModel>(value);
        }
    }
}