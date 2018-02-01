using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Managers.MapperManager.EntityMappers
{
    public class CustomerMapper : GeneralMapper<CustomerDTO, Customer>
    {
        public CustomerMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DTO.CustomerDTO, Customer>()));
        }

        public override IEnumerable<Customer> MapToCollectionObjects(IEnumerable<CustomerDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<CustomerDTO>, IEnumerable<Customer>>(collectValues);
        }

        public override Customer MapToObject(CustomerDTO value)
        {
            return Mapper.Map<CustomerDTO, Customer>(value);
        }
    }
}
