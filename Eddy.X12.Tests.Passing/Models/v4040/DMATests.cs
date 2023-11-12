using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*x*ez*2*z5*E*J*sD*D0*TO";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "x",
			StateOrProvinceCode = "ez",
			ReferenceIdentification2 = "2",
			StateOrProvinceCode2 = "z5",
			ApplicantTypeCode = "E",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "J",
			CountryCode = "sD",
			LanguageCode = "D0",
			StatusCode = "TO",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "z5", true)]
	[InlineData("2", "", false)]
	[InlineData("", "z5", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "J";
			subject.CountryCode = "sD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "sD", true)]
	[InlineData("J", "", false)]
	[InlineData("", "sD", false)]
	public void Validation_AllAreRequiredCodeForLicensingCertificationRegistrationOrAccreditationAgency(string codeForLicensingCertificationRegistrationOrAccreditationAgency, string countryCode, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = codeForLicensingCertificationRegistrationOrAccreditationAgency;
		subject.CountryCode = countryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "2";
			subject.StateOrProvinceCode2 = "z5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D0", "sD", true)]
	[InlineData("D0", "", false)]
	[InlineData("", "sD", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string countryCode, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.CountryCode = countryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "2";
			subject.StateOrProvinceCode2 = "z5";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "J";
			subject.CountryCode = "sD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TO", "2", true)]
	[InlineData("TO", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBStatusCode(string statusCode, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.StatusCode = statusCode;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "2";
			subject.StateOrProvinceCode2 = "z5";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "J";
			subject.CountryCode = "sD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
