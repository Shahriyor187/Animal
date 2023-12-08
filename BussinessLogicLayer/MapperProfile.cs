using Animals.Dtos;
using AutoMapper;
using BussinessLogicLayer.Dtos;
using BussinessLogicLayer.Dtos.CategoryDto;
using DataAccsesLayer.Entities;

namespace Animals
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
           
            CreateMap<Animal, AnimalDto>()
        .ReverseMap();
            CreateMap<Animal, AddAnimaldto>()
                .ReverseMap();
            CreateMap<Animal, UpdateDto>()
                .ReverseMap();
            CreateMap<AnimalCategory, AnimalCategoryDto>()
                .ReverseMap();
            CreateMap<AnimalCategory, AddCategoryDto>()
                .ReverseMap();
            CreateMap<AddAnimaldto, Animal>()
                .ReverseMap();
        }

    }
}
