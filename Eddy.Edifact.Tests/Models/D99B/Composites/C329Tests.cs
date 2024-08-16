using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C329Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:7:8";

		var expected = new C329_PatternDescription()
		{
			FrequencyCode = "n",
			DespatchPatternCoded = "7",
			DespatchPatternTimingCoded = "8",
		};

		var actual = Map.MapComposite<C329_PatternDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
