using AutoMapper;
using Model.DTO;
using Model.Models;
using Model.ViewModel;
using Models.DTO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserDTO>();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<List<Users>, List<UserDTO>>()
                .ConvertUsing(src => src.Select(e => new UserDTO { Name = e.Name, Id = e.Id, IdRole = e.IdRole, Email = e.Email}).ToList());

            CreateMap<UserViewModel, Users>();

            CreateMap<UserViewModel, UserDTO>();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
