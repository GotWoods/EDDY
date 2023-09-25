using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*J*oG*I*Uo*v*K*C5*Ad*Ym";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "J",
			StateOrProvinceCode = "oG",
			ReferenceIdentification2 = "I",
			StateOrProvinceCode2 = "Uo",
			ApplicantTypeCode = "v",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "K",
			CountryCode = "C5",
			LanguageCode = "Ad",
			StatusCode = "Ym",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "Uo", true)]
	[InlineData("I", "", false)]
	[InlineData("", "Uo", false)]
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
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "K";
			subject.CountryCode = "C5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "C5", true)]
	[InlineData("K", "", false)]
	[InlineData("", "C5", false)]
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
			subject.ReferenceIdentification2 = "I";
			subject.StateOrProvinceCode2 = "Uo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ad", "C5", true)]
	[InlineData("Ad", "", false)]
	[InlineData("", "C5", true)]
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
			subject.ReferenceIdentification2 = "I";
			subject.StateOrProvinceCode2 = "Uo";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "K";
			subject.CountryCode = "C5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ym", "I", true)]
	[InlineData("Ym", "", false)]
	[InlineData("", "I", true)]
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
			subject.ReferenceIdentification2 = "I";
			subject.StateOrProvinceCode2 = "Uo";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "K";
			subject.CountryCode = "C5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
