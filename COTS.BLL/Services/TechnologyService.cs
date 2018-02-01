using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Managers.MapperManager;
using COTS.BLL.Interfaces;

namespace COTS.BLL.Services
{
    public class TechnologyService : ITechnologyService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public TechnologyService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public TechnologyDTO GetOne(string id)
        {
            return mapperUnitOfWork.TechnologyDTOMapper.MapToObject(UnitOfWork.Technologies.Get(id));
        }

        public IEnumerable<TechnologyDTO> GetAll()
        {
            return mapperUnitOfWork.TechnologyDTOMapper.MapToCollectionObjects(UnitOfWork.Technologies.GetAll());
        }
    }
}
