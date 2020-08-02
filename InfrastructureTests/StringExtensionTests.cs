using Infrastructure.Extensions;
using NUnit.Framework;

namespace InfrastructureTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {

        }


        [Test]
        [TestCase("Hello World", "hello_world")]
        [TestCase("Panthera Prime Stock", "panthera_prime_stock")]
        public void WhenGettingSnakeCase(string input, string output)
        {
            Assert.That(input.ToSnakeCase(), Is.EqualTo(output));
        }
    }
}
