using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class IFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IFT++H";

		var expected = new IFT_InteractiveFreeText()
		{
			FreeTextQualification = null,
			FreeText = "H",
		};

		var actual = Map.MapObject<IFT_InteractiveFreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
