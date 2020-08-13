using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAbstractions.Interfaces
{
    public interface IHttpService
    {
        ServiceResponseScalar<Stream> Post(string uri, IEnumerable<KeyValuePair<string, string>> headers);
        ServiceResponseScalar<Stream> Get(string uri);

        Task<Stream> PostAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken token = new CancellationToken());
        Task<Stream> GetAsync(string uri);
    }
}