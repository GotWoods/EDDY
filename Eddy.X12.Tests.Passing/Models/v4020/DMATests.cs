using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*d*Ac*8*EE*M*Y*80*qm*O5";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "d",
			StateOrProvinceCode = "Ac",
			ReferenceIdentification2 = "8",
			StateOrProvinceCode2 = "EE",
			ApplicantTypeCode = "M",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Y",
			CountryCode = "80",
			LanguageCode = "qm",
			StatusCode = "O5",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "EE", true)]
	[InlineData("8", "", false)]
	[InlineData("", "EE", false)]
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
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Y";
			subject.CountryCode = "80";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "80", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "80", false)]
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
			subject.ReferenceIdentification2 = "8";
			subject.StateOrProvinceCode2 = "EE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qm", "80", true)]
	[InlineData("qm", "", false)]
	[InlineData("", "80", true)]
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
			subject.ReferenceIdentification2 = "8";
			subject.StateOrProvinceCode2 = "EE";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Y";
			subject.CountryCode = "80";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O5", "8", true)]
	[InlineData("O5", "", false)]
	[InlineData("", "8", true)]
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
			subject.ReferenceIdentification2 = "8";
			subject.StateOrProvinceCode2 = "EE";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Y";
			subject.CountryCode = "80";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
