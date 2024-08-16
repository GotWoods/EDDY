using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C329Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:V:8";

		var expected = new C329_PatternDescription()
		{
			FrequencyCoded = "E",
			DespatchPatternCoded = "V",
			DespatchPatternTimingCoded = "8",
		};

		var actual = Map.MapComposite<C329_PatternDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
