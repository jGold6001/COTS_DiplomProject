using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Utils.MapperManager;
using COTS.DAL.Repositories;

namespace COTS.BLL.Services
{
    public class SectorService : ISectorService
    {
        IUnitOfWork UnitOfWork { get; set; }
        SectorRepository sectorRepository;
        MapperUnitOfWork mapperUnitOfWork;

        public SectorService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            sectorRepository = UnitOfWork.Sectors as SectorRepository;
            this.mapperUnitOfWork = new MapperUnitOfWork();
        }

        public IEnumerable<SectorDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SectorDTO> FindAllBySeance(long? seanceId)
        {
            return mapperUnitOfWork.SectorDTOMapper.MapToCollectionObjects(sectorRepository.FindAllBySeance(seanceId.Value));
        }

        public SectorDTO GetOne(long? id)
        {
            return mapperUnitOfWork.SectorDTOMapper.MapToObject(sectorRepository.Get(id));
        }
    }
}
