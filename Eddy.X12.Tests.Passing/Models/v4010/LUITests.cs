using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LUITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUI*S*4g*2*i*n";

		var expected = new LUI_LanguageUse()
		{
			IdentificationCodeQualifier = "S",
			IdentificationCode = "4g",
			Description = "2",
			UseOfLanguageIndicator = "i",
			LanguageProficiencyIndicator = "n",
		};

		var actual = Map.MapObject<LUI_LanguageUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "4g", true)]
	[InlineData("S", "", false)]
	[InlineData("", "4g", false)]
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
			subject.UseOfLanguageIndicator = "i";
			subject.Description = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("i", "4g", "2", true)]
	[InlineData("i", "", "", false)]
	[InlineData("", "4g", "2", true)]
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
			subject.IdentificationCodeQualifier = "S";
			subject.IdentificationCode = "4g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
