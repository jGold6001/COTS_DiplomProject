using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class UserFullViewModelMapper : GeneralMapper<UserDTO, UserFullViewModel>
    {
        public UserFullViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserFullViewModel>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.UserDetailsDTO.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.UserDetailsDTO.LastName))
                .ForMember(d => d.Position, opt => opt.MapFrom(src => src.UserDetailsDTO.Position))
            ));
        }

        public override IEnumerable<UserFullViewModel> MapToCollectionObjects(IEnumerable<UserDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserFullViewModel>>(collectValues);
        }

        public override UserFullViewModel MapToObject(UserDTO value)
        {
            return Mapper.Map<UserDTO, UserFullViewModel>(value);
        }
    }
}