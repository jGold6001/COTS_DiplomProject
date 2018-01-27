using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IPlaceService
    {      
        PlaceDTO GetOne(long? id);
        IEnumerable<PlaceDTO> GetAllByCityCinemaAndHall(string cityId, string cinemaId, string hallName);
        void AddOrUpdate(PlaceDTO placeDTO);
    }
}
