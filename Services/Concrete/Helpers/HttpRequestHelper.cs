//using System;
//using System.IO;
//using System.Net;
//using Domain.Enums;
//using Infrastructure.Extensions;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//namespace Services.Concrete.Helpers
//{
//    public static class HttpRequestHelper
//    {
//        public static JToken GetItemStatistics(string itemString)
//        {
//            var request = BuildWebRequest("items", itemString.ToSnakeCase(), "statistics");

//            using (var response = request.GetResponse())
//            using (var stream = response.GetResponseStream())
//            using (var reader = new StreamReader(stream))
//            using (var jsonReader = new JsonTextReader(reader))
//            {
//                return JToken.ReadFrom(jsonReader);
//            }
//        }

//        public static JToken GetItemOrders(string itemString)
//        {
//            var request = BuildWebRequest("items", itemString.ToSnakeCase(), "orders");


//            using (var response = request.GetResponse())
//            using (var stream = response.GetResponseStream())
//            using (var reader = new StreamReader(stream))
//            using (var jsonReader = new JsonTextReader(reader))
//            {
//                return JToken.ReadFrom(jsonReader);
//            }
//        }

//        public static void TestProfileState(string username)
//        {
//            var request = BuildWebRequest("profile");
//        }

//        private static Uri BuildRequestUri(params string[] path)
//        {
//            return new Uri("https://api.warframe.market/v1/" + string.Join("/", path));
//        }

//        private static WebRequest BuildWebRequest(params string[] path)
//        {
//            var request = WebRequest.Create(BuildRequestUri(path));

//            return request;
//        }
//    }
//}
