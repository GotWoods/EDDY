using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class EDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EDT+0+V+1+s";

		var expected = new EDT_EditingDetails()
		{
			EditFieldLengthMeasure = "0",
			EditMaskFormatIdentifier = "V",
			EditMaskRepresentationCode = "1",
			FreeTextFormatCode = "s",
		};

		var actual = Map.MapObject<EDT_EditingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
