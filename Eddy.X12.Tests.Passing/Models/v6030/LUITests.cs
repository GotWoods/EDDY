using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LUITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUI*8*MZ*O*u*0";

		var expected = new LUI_LanguageUse()
		{
			IdentificationCodeQualifier = "8",
			IdentificationCode = "MZ",
			Description = "O",
			UseOfLanguageIndicatorCode = "u",
			LanguageProficiencyIndicatorCode = "0",
		};

		var actual = Map.MapObject<LUI_LanguageUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "MZ", true)]
	[InlineData("8", "", false)]
	[InlineData("", "MZ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UseOfLanguageIndicatorCode) || !string.IsNullOrEmpty(subject.UseOfLanguageIndicatorCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.UseOfLanguageIndicatorCode = "u";
			subject.Description = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("u", "MZ", "O", true)]
	[InlineData("u", "", "", false)]
	[InlineData("", "MZ", "O", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UseOfLanguageIndicatorCode(string useOfLanguageIndicatorCode, string identificationCode, string description, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		//Required fields
		//Test Parameters
		subject.UseOfLanguageIndicatorCode = useOfLanguageIndicatorCode;
		subject.IdentificationCode = identificationCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "8";
			subject.IdentificationCode = "MZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
