using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LUITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUI*lg*1*l";

		var expected = new LUI_LanguageUse()
		{
			LanguageCode = "lg",
			Description = "1",
			UseOfLanguageIndicator = "l",
		};

		var actual = Map.MapObject<LUI_LanguageUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("l", "lg", "1", true)]
	[InlineData("l", "", "", false)]
	[InlineData("", "lg", "1", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UseOfLanguageIndicator(string useOfLanguageIndicator, string languageCode, string description, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		//Required fields
		//Test Parameters
		subject.UseOfLanguageIndicator = useOfLanguageIndicator;
		subject.LanguageCode = languageCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
