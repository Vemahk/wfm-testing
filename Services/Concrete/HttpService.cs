using System.Net.Http;
using ServiceAbstractions.Interfaces;

namespace Services.Concrete
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

    }
}