using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class IFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IFT++z";

		var expected = new IFT_InteractiveFreeText()
		{
			FreeTextQualification = null,
			FreeText = "z",
		};

		var actual = Map.MapObject<IFT_InteractiveFreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
