using System;

namespace Infrastructure.Attributes
{
    public class JsonValueAttribute : EnumStringifyAttributeBase
    {
        public JsonValueAttribute(string jsonValue) : base(jsonValue)
        {
        }

        public string JsonValue => Value;
    }
}