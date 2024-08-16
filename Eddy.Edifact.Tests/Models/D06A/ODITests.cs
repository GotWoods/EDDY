using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class ODITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODI+r+a";

		var expected = new ODI_OriginAndDestinationDetails()
		{
			LocationIdentifier = "r",
			SequencePositionIdentifier = "a",
		};

		var actual = Map.MapObject<ODI_OriginAndDestinationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
