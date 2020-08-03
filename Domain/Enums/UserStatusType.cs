using System;

namespace Domain.Enums
{
    public enum UserStatusType
    {
        Unknown = 0,
        Offline = 1,
        Online = 2,
        OnlineInGame = 3
    }
    public static class UserStatusTypeConverter
    {
        public static UserStatusType FromString(string input)
        {
            switch (input.ToLowerInvariant())
            {
                default: return UserStatusType.Unknown;
            }
        }

        public static string ToOutString(this UserStatusType type)
        {
            switch (type)
            {
                case UserStatusType.Unknown:
                    throw new ArgumentException("PlatformType.Unknown cannot be converted.");
                default:
                    return string.Empty;
            }
        }
    }
}
