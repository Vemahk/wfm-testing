using System;
using ServiceAbstractions.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using ServiceAbstractions;

namespace Services.Concrete
{
    /// <summary>
    /// https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
    /// </summary>
    public class HttpService : Service, IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(ILogger logger) : base(logger)
        {
            _httpClient = new HttpClient();
        }

        //I don't think this is well liked...
        public ServiceResponseScalar<Stream> Post(string uri, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var serviceResponse = new ServiceResponseScalar<Stream>("Success");

            try
            {
                var task = PostAsync(uri, headers);
                Task.WaitAll(task);
                serviceResponse.Scalar = task.Result;
            }
            catch (Exception e)
            {
                var headersAsString = string.Join(", ", headers.Select(kv => $"{kv.Key}={kv.Value}"));
                var detailedError = $"Failed to retrieve POST stream from URI: {uri} with headers: {headersAsString}";
                LogException(e, detailedError);

                serviceResponse.SetError("Failed to retrieve POST stream for request.");
            }

            return serviceResponse;
        }

        public ServiceResponseScalar<Stream> Get(string uri)
        {
            var serviceResponse = new ServiceResponseScalar<Stream>("Success");

            try
            {
                var task = GetAsync(uri);
                Task.WaitAll(task);
                serviceResponse.Scalar = task.Result;
            }
            catch (Exception e)
            {
                LogException(e, $"Failed to retrieve GET stream from URI: {uri}");

                serviceResponse.SetError("Failed to retrieve GET stream for request.");
            }

            return serviceResponse;
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