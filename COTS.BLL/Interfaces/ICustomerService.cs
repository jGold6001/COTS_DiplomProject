using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ICustomerService
    {
        void AddOrUpdate(CustomerDTO customerDTO);
        CustomerDTO GetOne(string id);
        IEnumerable<CustomerDTO> GetAll();
        void Delete(string id);
    }
}
