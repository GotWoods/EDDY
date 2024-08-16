using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRE++J";

		var expected = new PRE_PriceDetails()
		{
			PriceInformation = null,
			SubLineItemPriceChangeOperationCode = "J",
		};

		var actual = Map.MapObject<PRE_PriceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
