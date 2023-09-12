using App.Data.Entities;
using App.WebAPI.DTOs;
using AutoMapper;

namespace App.WebAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, ProductEntity>().ReverseMap();
            CreateMap<ProductUpdateDto, ProductEntity>().ReverseMap();
        }
    }
}
