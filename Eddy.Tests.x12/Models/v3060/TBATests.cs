using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TBATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBA**4*1";

		var expected = new TBA_TemporaryBuydownAdjustment()
		{
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Percent = 1,
		};

		var actual = Map.MapObject<TBA_TemporaryBuydownAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
