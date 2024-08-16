using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class PRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRE++X";

		var expected = new PRE_PriceDetails()
		{
			PriceInformation = null,
			SubLinePriceChangeCoded = "X",
		};

		var actual = Map.MapObject<PRE_PriceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
