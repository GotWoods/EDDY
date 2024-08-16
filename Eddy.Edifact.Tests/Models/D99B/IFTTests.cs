using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class IFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IFT++8";

		var expected = new IFT_InteractiveFreeText()
		{
			FreeTextQualification = null,
			FreeTextValue = "8",
		};

		var actual = Map.MapObject<IFT_InteractiveFreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
