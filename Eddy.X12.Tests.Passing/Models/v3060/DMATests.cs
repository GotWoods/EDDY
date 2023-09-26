using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*5*Xr*8*ji*a*y*h5*wP";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "5",
			StateOrProvinceCode = "Xr",
			ReferenceIdentification2 = "8",
			StateOrProvinceCode2 = "ji",
			ApplicantTypeCode = "a",
			LicensingAgencyCode = "y",
			CountryCode = "h5",
			LanguageCode = "wP",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "ji", true)]
	[InlineData("8", "", false)]
	[InlineData("", "ji", false)]
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
			subject.LicensingAgencyCode = "y";
			subject.CountryCode = "h5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "h5", true)]
	[InlineData("y", "", false)]
	[InlineData("", "h5", false)]
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
			subject.ReferenceIdentification2 = "8";
			subject.StateOrProvinceCode2 = "ji";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
