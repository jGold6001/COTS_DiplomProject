using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class CustomerViewModelMapper : GeneralMapper<CustomerDTO, CustomerViewModel>
    {
        public CustomerViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap< CustomerDTO, CustomerViewModel>()));
        }

        public override IEnumerable<CustomerViewModel> MapToCollectionObjects(IEnumerable< CustomerDTO> collectValues)
        {
            return Mapper.Map<IEnumerable< CustomerDTO>, IEnumerable<CustomerViewModel>>(collectValues);
        }

        public override CustomerViewModel MapToObject( CustomerDTO value)
        {
            return Mapper.Map< CustomerDTO, CustomerViewModel>(value);
        }
    }
}