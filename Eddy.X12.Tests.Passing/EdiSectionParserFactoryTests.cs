using Eddy.x12;
using Eddy.x12.Models.v8040;

namespace Eddy.X12.Tests.Passing
{
    public class EdiSectionParserFactoryTests
    {
        [Fact]
        public void ShouldGetOneThatDoesNotInherit()
        {
            var results = EdiSectionParserFactory.LoadSegmentProviders();
            Assert.NotNull(results);
            Assert.Equivalent(typeof(x12.Models.v4010.B2_BeginningSegmentForShipmentInformationTransaction), results["4010.B2"]);
        }

        [Fact]
        public void ShouldGetOneThatInherits()
        {
            var results = EdiSectionParserFactory.LoadSegmentProviders();
            Assert.NotNull(results);
            Assert.Equivalent(typeof(x12.Models.v4020.B2_BeginningSegmentForShipmentInformationTransaction), results["4020.B2"]);
        }
    }
}
