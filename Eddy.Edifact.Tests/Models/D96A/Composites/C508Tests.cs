using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C508Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:e";

		var expected = new C508_LanguageDetails()
		{
			LanguageCoded = "V",
			Language = "e",
		};

		var actual = Map.MapComposite<C508_LanguageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
