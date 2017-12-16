using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IPurchaseService
    {
        void AddOrUpdate(PurchaseDTO purchaseDTO);
        PurchaseDTO GetOne(string id);
        void Delete(string id);
        IEnumerable<PurchaseDTO> GetAll();
    }
}
