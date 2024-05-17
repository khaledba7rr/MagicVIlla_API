using MagicVIlla_website.Models.DTOs.VillaNumberDTOs;

namespace MagicVIlla_website.Services.IServices
{
    public interface IVillaNumberService
    {
        public Task<T> GetAllVillaNumbers<T>();
        public Task<T> GetVillaNumber<T>(int id);
        public Task<T> CreateVillaNumber<T>(VillaNumberCreateDTO villa);
        public Task<T> UpdateVilla<T>(VillaNumberUpdateDTO villa);
        public Task<T> DeleteVilla<T>(int id);

    }
}
