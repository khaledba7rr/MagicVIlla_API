using AutoMapper;
using MagicVIlla_website.Models.DTOs.VillaDTOs;
using MagicVIlla_website.Models.DTOs.VillaNumberDTOs;

namespace MagicVIlla_website
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {

            CreateMap<VillaDTO, VillaCreationDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdatDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();


        }
    }
}
