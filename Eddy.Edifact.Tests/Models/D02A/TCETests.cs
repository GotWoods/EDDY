using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A;

public class TCETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TCE+D+";

		var expected = new TCE_TimeAndCertainty()
		{
			DateOrTimeOrPeriodText = "D",
			Certainty = null,
		};

		var actual = Map.MapObject<TCE_TimeAndCertainty>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
