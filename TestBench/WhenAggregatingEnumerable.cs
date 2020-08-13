using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestBench
{
    [TestFixture]
    public class WhenAggregatingEnumerable
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {

        }

        [Test]
        public void ThenLooksLikeJson()
        {
            var dict = new Dictionary<string, string> {{"a", "1"}, {"b", "2"}, {"c", "3"}};

            Console.WriteLine($"{{{AggregateKVPair(dict)}}}");
        }

        private string AggregateKVPair(IEnumerable<KeyValuePair<string, string>> kvEnum)
        {
            return string.Join(", ", kvEnum.Select(kv => $"\"{kv.Key}\": '{kv.Value}'"));
        }
    }
}