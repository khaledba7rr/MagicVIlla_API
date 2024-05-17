using AutoMapper;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Models.DTOs.VillaDTOs;
using MagicVIlla_VillaAPI.Models.DTOs.VillaNumberDTOs;

namespace MagicVIlla_VillaAPI
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();

            CreateMap<Villa, VillaCreationDTO>().ReverseMap();

            CreateMap<Villa, VillaUpdatDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaDTO>().ReverseMap();

        }
    }
}
