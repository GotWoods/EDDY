using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class EDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EDT+b+K+u+9";

		var expected = new EDT_EditingDetails()
		{
			EditFieldLength = "b",
			EditMask = "K",
			EditMaskRepresentationCode = "u",
			TextFormattingCoded = "9",
		};

		var actual = Map.MapObject<EDT_EditingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
