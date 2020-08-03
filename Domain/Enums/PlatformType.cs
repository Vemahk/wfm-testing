using System;

namespace Domain.Enums
{
    public enum PlatformType
    {
        Unknown,
        PC,
        XBox,
        Switch
    }

    public static class PlatformTypeConverter
    {
        public static PlatformType FromString(string input)
        {
            switch (input.ToLowerInvariant())
            {
                case "pc": return PlatformType.PC;
                case "xbox": return PlatformType.XBox;
                case "switch": return PlatformType.Switch;
                default: return PlatformType.Unknown;
            }
        }

        public static string ToOutString(this PlatformType type)
        {
            switch (type)
            {
                case PlatformType.PC:
                case PlatformType.XBox:
                case PlatformType.Switch:
                    return type.ToString().ToLower();
                case PlatformType.Unknown:
                    throw new ArgumentException("PlatformType.Unknown cannot be converted.");
                default:
                    return string.Empty;
            }
        }
    }
}