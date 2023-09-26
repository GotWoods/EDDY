using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TBATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBA**8*8";

		var expected = new TBA_TemporaryBuydownAdjustment()
		{
			CompositeUnitOfMeasure = null,
			Quantity = 8,
			PercentageAsDecimal = 8,
		};

		var actual = Map.MapObject<TBA_TemporaryBuydownAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
