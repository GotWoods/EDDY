using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LUITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUI*F*TW*g*F*r";

		var expected = new LUI_LanguageUse()
		{
			IdentificationCodeQualifier = "F",
			IdentificationCode = "TW",
			Description = "g",
			UseOfLanguageIndicator = "F",
			LanguageProficiencyIndicator = "r",
		};

		var actual = Map.MapObject<LUI_LanguageUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "TW", true)]
	[InlineData("F", "", false)]
	[InlineData("", "TW", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UseOfLanguageIndicator) || !string.IsNullOrEmpty(subject.UseOfLanguageIndicator) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.UseOfLanguageIndicator = "F";
			subject.Description = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("F", "TW", "g", true)]
	[InlineData("F", "", "", false)]
	[InlineData("", "TW", "g", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UseOfLanguageIndicator(string useOfLanguageIndicator, string identificationCode, string description, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		//Required fields
		//Test Parameters
		subject.UseOfLanguageIndicator = useOfLanguageIndicator;
		subject.IdentificationCode = identificationCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "TW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
