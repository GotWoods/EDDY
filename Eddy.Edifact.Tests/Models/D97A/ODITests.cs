using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ODITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODI+1";

		var expected = new ODI_OriginAndDestinationDetails()
		{
			PlaceLocationIdentification = "1",
		};

		var actual = Map.MapObject<ODI_OriginAndDestinationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
