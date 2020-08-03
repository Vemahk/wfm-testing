using System.IO;
using Domain.Models;
using Domain.Models.Orders;
using JsonService.Services.Abstractions;
using JsonService.Services.Mapping;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonService.Services
{
    public class JsonRequestService : IJsonRequestService
    {
        public TObject GetWfmObjectFromJson<TObject>(Stream stream) where TObject : BaseWfmObject
        {
            var token = TokenizeIncomingJson(stream);
            return JsonMapping.Parse<TObject>(token);
        }

        private JToken TokenizeIncomingJson(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            using(var jsonReader = new JsonTextReader(reader))
            {
                return JToken.ReadFrom(jsonReader);
            }
        }
    }
}