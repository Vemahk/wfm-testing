using Domain.Models.Orders;
using JsonService.Services;
using JsonService.Services.Abstractions;
using JsonServiceTests.Helpers;
using NUnit.Framework;

namespace JsonServiceTests
{
    [TestFixture]
    public class WhenParsingJson
    {
        private IJsonRequestService _jsonRequestService;

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            _jsonRequestService = new JsonRequestService();
        }

        [Test]
        public void ThenParsingValidOrderObjectWorks()
        {
            Order order = null;

            using (var stream = FileHelper.GetFileStream("order_test.json"))
            {
                order = _jsonRequestService.GetOrderFromJson(stream);
            }

            Assert.That(order, Is.Not.Null, "Order object returned null... No error?");
        }
    }
}