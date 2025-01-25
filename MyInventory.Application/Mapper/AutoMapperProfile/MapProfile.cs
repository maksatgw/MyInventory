using AutoMapper;
using MyInventory.Application.DTO.EquipmentDtos;
using MyInventory.Application.DTO.EquipmentImageDtos;
using MyInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Mapper.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Equipment, EquipmentDto>()
           .ForMember(dest => dest.DateAdded, 
                      opt => opt.MapFrom(src => src.DateAdded.ToShortDateString()))
            .ForMember(dest => dest.DateUpdated,
                       opt => opt.MapFrom(src => src.DateUpdated.ToShortDateString()));
            CreateMap<EquipmentImage, EquipmentImageDto>();
        }
    }
}
