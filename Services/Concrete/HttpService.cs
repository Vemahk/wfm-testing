using ServiceAbstractions.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Concrete
{
    /// <summary>
    /// https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
    /// </summary>
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        //I don't think this is well liked...
        public Stream Post(string uri, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var task = PostAsync(uri, headers);
            Task.WaitAll(task);

            return task.Result;
        }

        public Stream Get(string uri)
        {
            var task = GetAsync(uri);
            Task.WaitAll(task);

            return task.Result;
        }

        public async Task<Stream> PostAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken token = new CancellationToken())
        {
            var content = new FormUrlEncodedContent(headers);

            try
            {
                var response = await _httpClient.PostAsync(uri, content, token);
                return await response.Content.ReadAsStreamAsync();
            }
            catch (TaskCanceledException e)
            {
                //hrm.
                return null;
            }
        }

        public async Task<Stream> GetAsync(string uri)
        {
            return await _httpClient.GetStreamAsync(uri);
        }
    }
}