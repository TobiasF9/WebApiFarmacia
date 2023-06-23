using AutoMapper;
using Model.Models;
using Models.DTO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings.Profiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicines, MedicineDTO>();
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<List<Medicines>, List<MedicineDTO>>()
                .ConvertUsing(src => src.Select(e => new MedicineDTO { Name = e.Name, Id = e.Id, Price = e.Price, Manufacturer = e.Manufacturer }).ToList());

            CreateMap<MedicineViewModel, Medicines>();

            CreateMap<MedicineViewModel, MedicineDTO>();
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
