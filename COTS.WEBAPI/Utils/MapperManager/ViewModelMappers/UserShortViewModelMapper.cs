using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class UserShortViewModelMapper : GeneralMapper<UserDTO, UserShortViewModel>
    {
        public UserShortViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserShortViewModel>()));
        }

        public override IEnumerable<UserShortViewModel> MapToCollectionObjects(IEnumerable<UserDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserShortViewModel>>(collectValues);
        }

        public override UserShortViewModel MapToObject(UserDTO value)
        {
            return Mapper.Map<UserDTO, UserShortViewModel>(value);
        }
    }
}