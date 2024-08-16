using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01B;
using Eddy.Edifact.Models.D01B.Composites;

namespace Eddy.Edifact.Tests.Models.D01B;

public class ODITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODI+L+u";

		var expected = new ODI_OriginAndDestinationDetails()
		{
			LocationNameCode = "L",
			SequencePositionIdentifier = "u",
		};

		var actual = Map.MapObject<ODI_OriginAndDestinationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
