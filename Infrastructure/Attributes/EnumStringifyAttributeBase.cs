using System;

namespace Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class EnumStringifyAttributeBase : Attribute
    {
        protected EnumStringifyAttributeBase(string val)
        {
            Value = val;
        }

        protected string Value { get; }
    }
}