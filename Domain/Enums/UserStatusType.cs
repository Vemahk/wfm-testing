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
                case "offline": return UserStatusType.Offline;
                case "online": return UserStatusType.Online;
                case "online-ingame": return UserStatusType.OnlineInGame;
                default: return UserStatusType.Unknown;
            }
        }

        public static string ToOutString(this UserStatusType type)
        {
            switch (type)
            {
                case UserStatusType.Offline:
                case UserStatusType.Online:
                    return type.ToString().ToLowerInvariant();
                case UserStatusType.OnlineInGame:
                    return "online-ingame";
                case UserStatusType.Unknown:
                    throw new ArgumentException("PlatformType.Unknown cannot be converted.");
                default:
                    return string.Empty;
            }
        }
    }
}
