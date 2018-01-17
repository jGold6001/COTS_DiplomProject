using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IPurchaseClientDetailsService
    {
        void AddOrUpdate(PurchaseClientDetailsDTO purchaseClientDetailsDTO);
        PurchaseClientDetailsDTO GetOne(string id);
        IEnumerable<PurchaseClientDetailsDTO> GetAll();
        void Delete(string id);
    }
}
