using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IND*D7*Ed*0AUfs*m7*Dk*w*qP*CT*T*p7*B*Fc";

		var expected = new IND_AdditionalIndividualDemographicInformation()
		{
			CountryCode = "D7",
			StateOrProvinceCode = "Ed",
			CountyDesignator = "0AUfs",
			CityName = "m7",
			LanguageCode = "Dk",
			LanguageProficiencyIndicator = "w",
			LanguageCode2 = "qP",
			LanguageCode3 = "CT",
			IdentificationCodeQualifier = "T",
			IdentificationCode = "p7",
			IdentificationCodeQualifier2 = "B",
			IdentificationCode2 = "Fc",
		};

		var actual = Map.MapObject<IND_AdditionalIndividualDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "p7", true)]
	[InlineData("T", "", false)]
	[InlineData("", "p7", false)]
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
			subject.IdentificationCodeQualifier2 = "B";
			subject.IdentificationCode2 = "Fc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Fc", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Fc", false)]
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
			subject.IdentificationCodeQualifier = "T";
			subject.IdentificationCode = "p7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
