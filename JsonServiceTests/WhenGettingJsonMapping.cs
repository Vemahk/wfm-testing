using System;
using Domain.Models.Orders;
using JsonService.Services.Mapping;
using NUnit.Framework;

namespace JsonServiceTests
{
    [TestFixture]
    public class WhenGettingJsonMapping
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {

        }

        [Test]
        public void ThenGettingOrderMappingWorks()
        {
            Assert.That(JsonMapping.Get<Order>, Throws.Nothing);
        }

        [Test]
        public void ThenGettingUserMappingWorks()
        {
            Assert.That(JsonMapping.Get<User>, Throws.Nothing);
        }
    }
}