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
    public class SellsProfile : Profile
    {
        public SellsProfile()
        {
            CreateMap<Sells, SellsDTO>();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<List<Sells>, List<SellsDTO>>()
                .ConvertUsing(src => src.Select(e => new SellsDTO {Id = e.Id, IdMedicine = e.IdMedicine, IdUser = e.IdUser, SellDate = e.SellDate , Amount = e.Amount }).ToList());

            CreateMap<SellsViewModel, Sells>();

            CreateMap<SellsViewModel, SellsDTO>();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
