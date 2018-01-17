using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManeger
{
    public class CinemaViewModelMapper : GeneralMapper<CinemaDTO, CinemaViewModel>
    {
        public CinemaViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CinemaDTO, CinemaViewModel>()));
        }
        public override IEnumerable<CinemaViewModel> MapToCollectionObjects(IEnumerable<CinemaDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<CinemaDTO>, IEnumerable<CinemaViewModel>>(collectValues);
        }

        public override CinemaViewModel MapToObject(CinemaDTO value)
        {
            return Mapper.Map<CinemaDTO, CinemaViewModel>(value);
        }
    }
}