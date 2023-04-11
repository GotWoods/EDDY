using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IND*mh*eB*vlwYp*lJ*x1*c*ch*3d*o*tF*Z*zQ";

		var expected = new IND_AdditionalIndividualDemographicInformation()
		{
			CountryCode = "mh",
			StateOrProvinceCode = "eB",
			CountyDesignatorCode = "vlwYp",
			CityName = "lJ",
			LanguageCode = "x1",
			LanguageProficiencyIndicatorCode = "c",
			LanguageCode2 = "ch",
			LanguageCode3 = "3d",
			IdentificationCodeQualifier = "o",
			IdentificationCode = "tF",
			IdentificationCodeQualifier2 = "Z",
			IdentificationCode2 = "zQ",
		};

		var actual = Map.MapObject<IND_AdditionalIndividualDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("o", "tF", true)]
	[InlineData("", "tF", false)]
	[InlineData("o", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new IND_AdditionalIndividualDemographicInformation();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Z", "zQ", true)]
	[InlineData("", "zQ", false)]
	[InlineData("Z", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new IND_AdditionalIndividualDemographicInformation();
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
