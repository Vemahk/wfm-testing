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
        public void FixutreSetup()
        {

        }

        [Test]
        [TestCase(typeof(Order))]
        public void ThenGettingOrderMappingWorks(Type t)
        {
            Assert.That(() => JsonMapping.Get<Order>(), Throws.Nothing);
        }
    }
}