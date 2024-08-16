using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class ODITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODI+x+8";

		var expected = new ODI_OriginAndDestinationDetails()
		{
			LocationNameCode = "x",
			SequencePositionIdentifier = "8",
		};

		var actual = Map.MapObject<ODI_OriginAndDestinationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
