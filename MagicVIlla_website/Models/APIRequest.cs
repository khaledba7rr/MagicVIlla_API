using static MagicVilla_Utility.SD;

namespace MagicVIlla_website.Models
{
    public class APIRequest
    {
        public HttpVerb HttpVerb {  get; set; }
        public string Url { get; set; }
        public object? Data { get; set; }

    }
}
