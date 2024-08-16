using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GOR+h++++";

		var expected = new GOR_GovernmentalRequirements()
		{
			TransportMovementCoded = "h",
			GovernmentAction = null,
			GovernmentAction2 = null,
			GovernmentAction3 = null,
			GovernmentAction4 = null,
		};

		var actual = Map.MapObject<GOR_GovernmentalRequirements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
