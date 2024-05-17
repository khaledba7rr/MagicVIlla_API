using MagicVilla_Utility;
using MagicVIlla_website.Models;
using MagicVIlla_website.Models.DTOs.VillaDTOs;
using MagicVIlla_website.Services.IServices;
using static MagicVilla_Utility.SD;

namespace MagicVIlla_website.Services
{
    public class VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : BaseService(httpClientFactory), IVillaService
    {

        private string _apiUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        public async Task<T> CreateVilla<T>(VillaCreationDTO dto)
        {

            return await SendRequestAsync<T>(new APIRequest
            {
                Url = _apiUrl + "/api/VillaAPI/Create",
                Data = dto,
                HttpVerb = SD.HttpVerb.POST
            });
        }

        public async Task<T> DeleteVilla<T>(int id)
        {
            return await SendRequestAsync<T>(new APIRequest
            {
                Url = _apiUrl + $"/api/VillaAPI/Delete/{id}",
                HttpVerb = SD.HttpVerb.DELETE
            });
        }

        public async Task<T> GetAllVillas<T>()
        {
            return await SendRequestAsync<T>(new APIRequest
            {
                Url = _apiUrl + "/api/VillaAPI/GetAll",
                HttpVerb = SD.HttpVerb.GET
            });
        }

        public async Task<T> GetVilla<T>(int id)
        {
            return await SendRequestAsync<T>(new APIRequest
            {
                Url = _apiUrl + $"/api/VillaAPI/GetVilla/{id}",
                HttpVerb = SD.HttpVerb.GET
            });
        }

        public async Task<T> UpdateVilla<T>(VillaUpdatDTO dto)
        {
            return await SendRequestAsync<T>(new APIRequest
            {
                Url = _apiUrl + $"/api/VillaAPI/Update/{dto.Id}",
                Data = dto,
                HttpVerb = SD.HttpVerb.PUT
            });
        }
    }
}
