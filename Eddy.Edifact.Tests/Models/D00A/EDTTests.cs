using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class EDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EDT+c+I+d+7";

		var expected = new EDT_EditingDetails()
		{
			EditFieldLengthValue = "c",
			EditMaskFormatIdentifier = "I",
			EditMaskRepresentationCode = "d",
			FreeTextFormatCode = "7",
		};

		var actual = Map.MapObject<EDT_EditingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
