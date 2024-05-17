using MagicVIlla_website.Models;

namespace MagicVIlla_website.Services.IServices
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }

        Task<T> SendRequestAsync<T>(APIRequest request);
    }
}
