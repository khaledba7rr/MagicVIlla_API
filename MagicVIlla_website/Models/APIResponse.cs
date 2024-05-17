using System.Net;

namespace MagicVIlla_website.Models
{
    public class APIResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSucceess { get; set; } = true;
        public List<string>? Errors { get; set; }
        public object Result {  get; set; }
    }
}
