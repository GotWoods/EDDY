using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TCETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TCE+e+";

		var expected = new TCE_TimeAndCertainty()
		{
			DateOrTimeOrPeriodValue = "e",
			Certainty = null,
		};

		var actual = Map.MapObject<TCE_TimeAndCertainty>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
