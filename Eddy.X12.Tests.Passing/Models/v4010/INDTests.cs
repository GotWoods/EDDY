using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IND*5E*kc*QtD3q*24*fs*P*6o*X0*F*wW*L*Al";

		var expected = new IND_AdditionalIndividualDemographicInformation()
		{
			CountryCode = "5E",
			StateOrProvinceCode = "kc",
			CountyDesignator = "QtD3q",
			CityName = "24",
			LanguageCode = "fs",
			LanguageProficiencyIndicator = "P",
			LanguageCode2 = "6o",
			LanguageCode3 = "X0",
			IdentificationCodeQualifier = "F",
			IdentificationCode = "wW",
			IdentificationCodeQualifier2 = "L",
			IdentificationCode2 = "Al",
		};

		var actual = Map.MapObject<IND_AdditionalIndividualDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "wW", true)]
	[InlineData("F", "", false)]
	[InlineData("", "wW", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new IND_AdditionalIndividualDemographicInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "L";
			subject.IdentificationCode2 = "Al";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "Al", true)]
	[InlineData("L", "", false)]
	[InlineData("", "Al", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new IND_AdditionalIndividualDemographicInformation();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "wW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
