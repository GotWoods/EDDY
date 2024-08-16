using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class LANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LAN+t+";

		var expected = new LAN_Language()
		{
			LanguageCodeQualifier = "t",
			LanguageDetails = null,
		};

		var actual = Map.MapObject<LAN_Language>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredLanguageCodeQualifier(string languageCodeQualifier, bool isValidExpected)
	{
		var subject = new LAN_Language();
		//Required fields
		//Test Parameters
		subject.LanguageCodeQualifier = languageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
