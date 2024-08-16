using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class HANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HAN++";

		var expected = new HAN_HandlingInstructions()
		{
			HandlingInstructions = null,
			HazardousMaterial = null,
		};

		var actual = Map.MapObject<HAN_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
