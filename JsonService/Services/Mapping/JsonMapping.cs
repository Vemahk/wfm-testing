using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Domain.Models;
using Newtonsoft.Json.Linq;

namespace JsonService.Services.Mapping
{
    public abstract class JsonMapping
    {
        protected JsonMapping() {}

        private static readonly Dictionary<Type, JsonMapping> MappingDict = new Dictionary<Type, JsonMapping>();

        public static JsonMapping<TObject> Get<TObject>() where TObject : BaseWfmObject
        {
            var type = typeof(TObject);
            if (!MappingDict.TryGetValue(type, out var mapper))
            {
                var jsonMappingType = typeof(JsonMapping<TObject>);
                var applicableTypes = Assembly.GetAssembly(jsonMappingType).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(jsonMappingType)).ToList();

                if (applicableTypes.Count != 1)
                {
                    throw new ApplicationException($"JsonMapping for type {type.Name} does not have a one-to-one mapping.");
                }

                mapper = (JsonMapping) Activator.CreateInstance(applicableTypes.Single());
                MappingDict.Add(type, mapper);
            }

            return (JsonMapping<TObject>) mapper;
        }

        public static TObject Parse<TObject>(JToken token) where TObject : BaseWfmObject
        {
            return Get<TObject>().Parse(token);
        }
    }

    public abstract class JsonMapping<TObject> : JsonMapping where TObject : BaseWfmObject
    {
        public abstract TObject Parse(JToken token);

        protected void TokenNotNull(JToken token)
        {
            if(token == null)
                throw new ArgumentException($"Argument: '{nameof(token)}' cannot be null");
        }
    }
}