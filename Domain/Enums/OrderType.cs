using System;

namespace Domain.Enums
{
    public enum OrderType
    {
        Unknown = 0,
        Sell = 1,
        Buy = 2
    }

    public static class OrderTypeConverter
    {
        public static OrderType FromString(string input)
        {
            switch (input.ToLowerInvariant())
            {
                case "sell": return OrderType.Sell;
                case "buy": return OrderType.Buy;
                default: return OrderType.Unknown;
            }
        }

        public static string ToOutString(this OrderType type)
        {
            switch (type)
            {
                case OrderType.Sell:
                case OrderType.Buy:
                    return type.ToString().ToLower();
                case OrderType.Unknown:
                    throw new ArgumentException("PlatformType.Unknown cannot be converted.");
                default:
                    return string.Empty;
            }
        }
    }
}
