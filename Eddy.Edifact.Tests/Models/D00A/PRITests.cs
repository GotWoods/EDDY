using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRI++Z";

		var expected = new PRI_PriceDetails()
		{
			PriceInformation = null,
			SubLineItemPriceChangeOperationCode = "Z",
		};

		var actual = Map.MapObject<PRI_PriceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
