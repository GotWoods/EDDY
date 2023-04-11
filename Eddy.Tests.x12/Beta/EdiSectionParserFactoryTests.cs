using Eddy.x12;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Beta
{
    public class EdiSectionParserFactoryTests
    {
        [Fact]
        public void ShouldGetOne()
        {
            var results = EdiSectionParserFactory.LoadSegmentProviders();

            Assert.NotNull(results);
            Assert.Equivalent(typeof(AT7_ShipmentStatusDetails), results["AT7"]);
            Assert.Equivalent(typeof(B3_BeginningSegmentForCarriersInvoice), results["B3"]);

        }
    }
}
