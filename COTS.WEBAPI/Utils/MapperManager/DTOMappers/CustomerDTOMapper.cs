using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class CustomerDTOMapper : GeneralMapper<CustomerViewModel, CustomerDTO>
    {
        public CustomerDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, CustomerDTO>()));
        }

        public override IEnumerable<CustomerDTO> MapToCollectionObjects(IEnumerable<CustomerViewModel> collectValues)
        {
            return Mapper.Map<IEnumerable<CustomerViewModel>, IEnumerable<CustomerDTO>>(collectValues);
        }

        public override  CustomerDTO MapToObject(CustomerViewModel value)
        {
            return Mapper.Map<CustomerViewModel, CustomerDTO>(value);
        }
    }
}