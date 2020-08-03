using System.IO;
using JsonService.Services.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonService.Services
{
    public class JsonRequestService : IJsonRequestService
    {


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