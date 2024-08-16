using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class GORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GOR+N++++";

		var expected = new GOR_GovernmentalRequirements()
		{
			TransportMovementCode = "N",
			GovernmentAction = null,
			GovernmentAction2 = null,
			GovernmentAction3 = null,
			GovernmentAction4 = null,
		};

		var actual = Map.MapObject<GOR_GovernmentalRequirements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
