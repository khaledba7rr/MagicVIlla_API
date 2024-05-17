using MagicVilla_Utility;
using MagicVIlla_website.Models;
using MagicVIlla_website.Models.DTOs.VillaNumberDTOs;
using MagicVIlla_website.Services.IServices;

namespace MagicVIlla_website.Services
{
    public class VillaNumberService(IHttpClientFactory factory, IConfiguration configuration) : BaseService(factory), IVillaNumberService
    {
        string villaNumberApi = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        public async Task<T> CreateVillaNumber<T>(VillaNumberCreateDTO villa)
        {

            var response = await SendRequestAsync<T>(new APIRequest
            {
                Url = villaNumberApi + "/api/villaNo/Create",
                HttpVerb = SD.HttpVerb.POST,
                Data = villa
            });

            return response;

        }

        public async Task<T> DeleteVilla<T>(int id)
        {
            var response = await SendRequestAsync<T>(new APIRequest
            {
                Url = villaNumberApi + $"/api/villaNo/Delete/{id}",
                HttpVerb = SD.HttpVerb.DELETE
            });

            return response;
        }

        public async Task<T> GetAllVillaNumbers<T>()
        {
            var response = await SendRequestAsync<T>(new APIRequest
            {
                Url = villaNumberApi + "/api/villaNo/VillasNumbers",
                HttpVerb = SD.HttpVerb.GET
            });

            return response;
        }

        public async Task<T> GetVillaNumber<T>(int id)
        {
            var response = await SendRequestAsync<T>(new APIRequest
            {
                Url = villaNumberApi + $"/api/villaNo/VillaNumber/{id}",
                HttpVerb = SD.HttpVerb.GET
            });

            return response;
        }

        public async Task<T> UpdateVilla<T>(VillaNumberUpdateDTO villa)
        {
            var response = await SendRequestAsync<T>(new APIRequest
            {
                Url = villaNumberApi + $"/api/villaNo/Update",
                HttpVerb = SD.HttpVerb.PUT,
                Data = villa
            });

            return response;
        }
    }
}
