using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C329Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:z:d";

		var expected = new C329_PatternDescription()
		{
			FrequencyCode = "A",
			DespatchPatternCode = "z",
			DespatchPatternTimingCode = "d",
		};

		var actual = Map.MapComposite<C329_PatternDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
