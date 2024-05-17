using MagicVilla_Utility;
using MagicVIlla_website.Models;
using MagicVIlla_website.Services.IServices;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace MagicVIlla_website.Services
{
    public class BaseService(IHttpClientFactory httpClientFactory) : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

        public APIResponse ResponseModel { get; set; } = new ();

        public async Task<T> SendRequestAsync<T>(APIRequest request)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient("VillaApi");

                var message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                if(request.Data != null) 
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                message.Method = request.HttpVerb switch
                {
                    SD.HttpVerb.POST => HttpMethod.Post,
                    SD.HttpVerb.PUT => HttpMethod.Put,
                    SD.HttpVerb.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };

                HttpResponseMessage apiResponse = null;    

                apiResponse = await httpClient.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var finalResponse = JsonConvert.DeserializeObject<T>(apiContent);

                return finalResponse;
            }
            catch (Exception ex)
            {
                var apiResponse = new APIResponse
                {
                    IsSucceess = false,
                    Errors = new List<string>() { ex.ToString() }
                };

                var response = JsonConvert.SerializeObject(apiResponse);

                var finalResponse = JsonConvert.DeserializeObject<T>(response);

                return finalResponse;
            }
        }
    }
}
