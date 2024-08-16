using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class LANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LAN+T+";

		var expected = new LAN_Language()
		{
			LanguageQualifier = "T",
			LanguageDetails = null,
		};

		var actual = Map.MapObject<LAN_Language>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredLanguageQualifier(string languageQualifier, bool isValidExpected)
	{
		var subject = new LAN_Language();
		//Required fields
		//Test Parameters
		subject.LanguageQualifier = languageQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
