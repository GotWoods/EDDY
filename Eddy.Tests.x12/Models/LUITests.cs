using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LUITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUI*q*xl*7*7*G";

		var expected = new LUI_LanguageUse()
		{
			IdentificationCodeQualifier = "q",
			IdentificationCode = "xl",
			Description = "7",
			UseOfLanguageIndicatorCode = "7",
			LanguageProficiencyIndicatorCode = "G",
		};

		var actual = Map.MapObject<LUI_LanguageUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("q", "xl", true)]
	[InlineData("", "xl", false)]
	[InlineData("q", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", "", true)]
	[InlineData("7", "xl", "", false)]
	[InlineData("","xl", "", true)]
	[InlineData("7", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UseOfLanguageIndicatorCode(string useOfLanguageIndicatorCode, string identificationCode, string description, bool isValidExpected)
	{
		var subject = new LUI_LanguageUse();
		subject.UseOfLanguageIndicatorCode = useOfLanguageIndicatorCode;
		subject.IdentificationCode = identificationCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
