using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex SnakeRegex = new Regex(@"\w+\b", RegexOptions.Compiled);
        public static string ToSnakeCase(this string input)
        {
            return SnakeRegex.Matches(input)
                .GetValues().Select(v => v.ToLower())
                .Aggregate((total, next) => total + '_' + next);
        }

        private static IEnumerable<string> GetValues(this MatchCollection matches)
        {
            for(var i = 0; i < matches.Count; i++)
            {
                yield return matches[i].Value;
            }
        }
    }
}
