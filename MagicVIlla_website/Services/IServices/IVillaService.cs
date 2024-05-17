using MagicVIlla_website.Models.DTOs.VillaDTOs;

namespace MagicVIlla_website.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllVillas<T>();
        Task<T> GetVilla<T>(int id);
        Task<T> CreateVilla<T>(VillaCreationDTO dto);
        Task<T> UpdateVilla<T>(VillaUpdatDTO dto);
        Task<T> DeleteVilla<T>(int id);

    }
}
