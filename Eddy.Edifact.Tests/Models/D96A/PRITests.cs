using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRI++S";

		var expected = new PRI_PriceDetails()
		{
			PriceInformation = null,
			SubLinePriceChangeCoded = "S",
		};

		var actual = Map.MapObject<PRI_PriceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
