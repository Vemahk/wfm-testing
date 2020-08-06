
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infrastructure.Attributes;

namespace Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string Description<T>(this T e) where T : Enum
        {
            var enumType = typeof(T);
            var valueInfo = enumType.GetMember(e.ToString()).FirstOrDefault(x => x.DeclaringType == enumType);
            return valueInfo.GetAttributes<DescriptionAttribute>().FirstOrDefault()?.Description;
        }

        public static string JsonValue<T>(this T e) where T : Enum
        {
            var enumType = typeof(T);
            var valueInfo = enumType.GetMember(e.ToString()).FirstOrDefault(x => x.DeclaringType == enumType);
            return valueInfo.GetAttributes<JsonValueAttribute>().FirstOrDefault()?.JsonValue;
        }

        private static IEnumerable<T> GetAttributes<T>(this MemberInfo info) where T : Attribute
        {
            return info.GetCustomAttributes(typeof(T), false).AsEnumerable().Cast<T>();
        }
    }
}