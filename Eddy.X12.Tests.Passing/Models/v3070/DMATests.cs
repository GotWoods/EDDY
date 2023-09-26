using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*4*jj*X*fE*9*Q*9D*iD*fg";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "4",
			StateOrProvinceCode = "jj",
			ReferenceIdentification2 = "X",
			StateOrProvinceCode2 = "fE",
			ApplicantTypeCode = "9",
			LicensingAgencyCode = "Q",
			CountryCode = "9D",
			LanguageCode = "iD",
			StatusCode = "fg",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "fE", true)]
	[InlineData("X", "", false)]
	[InlineData("", "fE", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.LicensingAgencyCode = "Q";
			subject.CountryCode = "9D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "9D", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "9D", false)]
	public void Validation_AllAreRequiredLicensingAgencyCode(string licensingAgencyCode, string countryCode, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.LicensingAgencyCode = licensingAgencyCode;
		subject.CountryCode = countryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "X";
			subject.StateOrProvinceCode2 = "fE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iD", "9D", true)]
	[InlineData("iD", "", false)]
	[InlineData("", "9D", true)]
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
			subject.ReferenceIdentification2 = "X";
			subject.StateOrProvinceCode2 = "fE";
		}
		if(!string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.LicensingAgencyCode = "Q";
			subject.CountryCode = "9D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fg", "X", true)]
	[InlineData("fg", "", false)]
	[InlineData("", "X", true)]
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
			subject.ReferenceIdentification2 = "X";
			subject.StateOrProvinceCode2 = "fE";
		}
		if(!string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.LicensingAgencyCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.LicensingAgencyCode = "Q";
			subject.CountryCode = "9D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
