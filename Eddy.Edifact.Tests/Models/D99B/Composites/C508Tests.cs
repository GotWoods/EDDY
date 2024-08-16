using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C508Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:N";

		var expected = new C508_LanguageDetails()
		{
			LanguageNameCode = "p",
			LanguageName = "N",
		};

		var actual = Map.MapComposite<C508_LanguageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
