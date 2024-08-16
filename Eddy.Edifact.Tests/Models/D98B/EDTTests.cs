using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class EDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EDT+8+0+Z+k";

		var expected = new EDT_EditingDetails()
		{
			EditFieldLength = "8",
			EditMask = "0",
			EditMaskQualifier = "Z",
			TextFormattingCoded = "k",
		};

		var actual = Map.MapObject<EDT_EditingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
