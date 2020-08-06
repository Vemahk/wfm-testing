using System;

namespace Infrastructure.Attributes
{
    public class DescriptionAttribute : EnumStringifyAttributeBase
    {
        public DescriptionAttribute(string desc) : base(desc)
        {
        }

        public string Description => Value;
    }
}