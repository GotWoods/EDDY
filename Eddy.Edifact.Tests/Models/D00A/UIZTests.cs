using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UIZTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UIZ++v+f";

		var expected = new UIZ_InteractiveInterchangeTrailer()
		{
			DialogueReference = null,
			InterchangeControlCount = "v",
			DuplicateIndicator = "f",
		};

		var actual = Map.MapObject<UIZ_InteractiveInterchangeTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
