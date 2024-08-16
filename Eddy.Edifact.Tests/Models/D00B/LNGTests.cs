using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class LNGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LNG+D+";

		var expected = new LNG_Language()
		{
			LanguageCodeQualifier = "D",
			LanguageDetails = null,
		};

		var actual = Map.MapObject<LNG_Language>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredLanguageCodeQualifier(string languageCodeQualifier, bool isValidExpected)
	{
		var subject = new LNG_Language();
		//Required fields
		//Test Parameters
		subject.LanguageCodeQualifier = languageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
