using Infrastructure.Attributes;
using Infrastructure.Extensions;
using NUnit.Framework;

using DescriptionAttribute = Infrastructure.Attributes.DescriptionAttribute;

namespace InfrastructureTests
{
    [TestFixture]
    public class EnumExtensionTests
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {
        }

        [Test]
        [TestCase(EnumExtensionTester.Alpha, "ALPHA")]
        [TestCase(EnumExtensionTester.Beta, "BETA")]
        [TestCase(EnumExtensionTester.Gamma, "GAMMA")]
        [TestCase(EnumExtensionTester.Delta, "DELTA")]
        [TestCase(EnumExtensionTester.Blank, null)]
        public void WhenGettingDescriptionAttribute(EnumExtensionTester e, string expectedOutput)
        {
            Assert.That(e.Description(), Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase(EnumExtensionTester.Alpha, "alpha")]
        [TestCase(EnumExtensionTester.Beta, "beta")]
        [TestCase(EnumExtensionTester.Gamma, "gamma")]
        [TestCase(EnumExtensionTester.Delta, "delta")]
        [TestCase(EnumExtensionTester.Blank, null)]
        public void WhenGettingJsonValueAttribute(EnumExtensionTester e, string expectedOutput)
        {
            Assert.That(e.JsonValue(), Is.EqualTo(expectedOutput));
        }
    }

    public enum EnumExtensionTester
    {
        [Description("ALPHA")]
        [JsonValue("alpha")]
        Alpha,

        [Description("BETA")]
        [JsonValue("beta")]
        Beta,

        [Description("GAMMA")]
        [JsonValue("gamma")]
        Gamma,

        [Description("DELTA")]
        [JsonValue("delta")]
        Delta,

        Blank
    }
}