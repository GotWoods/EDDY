using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ODITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODI+K";

		var expected = new ODI_OriginAndDestinationDetails()
		{
			LocationNameCode = "K",
		};

		var actual = Map.MapObject<ODI_OriginAndDestinationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
