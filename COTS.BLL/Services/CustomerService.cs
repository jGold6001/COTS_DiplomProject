using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();

        }

        public void AddOrUpdate(CustomerDTO customerDTO)
        {
            var customer = mapperUnitOfWork.CustomerMapper.MapToObject(customerDTO);
            UnitOfWork.Customers.AddOrUpdate(customer);
        }

        public void Delete(string id)
        {
            var customer = UnitOfWork.Customers.Get(id);
            UnitOfWork.Customers.Delete(customer);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return mapperUnitOfWork.CustomerDTOMapper.MapToCollectionObjects(UnitOfWork.Customers.GetAll());
        }

        public CustomerDTO GetOne(string id)
        {
            return mapperUnitOfWork.CustomerDTOMapper.MapToObject(UnitOfWork.Customers.Get(id));
        }
    }
}
