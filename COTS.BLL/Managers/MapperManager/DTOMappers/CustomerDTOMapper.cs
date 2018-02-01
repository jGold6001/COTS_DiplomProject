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

    public class CustomerDTOMapper : GeneralMapper<Customer, CustomerDTO>
    {
        public CustomerDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()));
        }

        public override IEnumerable<CustomerDTO> MapToCollectionObjects(IEnumerable<Customer> collectValues)
        {
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(collectValues);
        }

        public override CustomerDTO MapToObject(Customer value)
        {
            return Mapper.Map<Customer, CustomerDTO>(value);
        }
    }
}
