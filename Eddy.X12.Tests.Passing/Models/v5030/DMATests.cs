using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*M*cr*6*h7*E*8*3D*qe*in*6d*m*r*Q*4*e*2*f*8x";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "M",
			StateOrProvinceCode = "cr",
			ReferenceIdentification2 = "6",
			StateOrProvinceCode2 = "h7",
			ApplicantTypeCode = "E",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8",
			CountryCode = "3D",
			LanguageCode = "qe",
			StatusCode = "in",
			CityName = "6d",
			Color = "m",
			Color2 = "r",
			MeasurementUnitQualifier = "Q",
			Height = 4,
			WeightUnitCode = "e",
			Weight = 2,
			Description = "f",
			CountryCode2 = "8x",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "h7", true)]
	[InlineData("6", "", false)]
	[InlineData("", "h7", false)]
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
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8";
			subject.CountryCode = "3D";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "Q";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "e";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "3D", true)]
	[InlineData("8", "", false)]
	[InlineData("", "3D", false)]
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
			subject.ReferenceIdentification2 = "6";
			subject.StateOrProvinceCode2 = "h7";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "Q";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "e";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qe", "3D", true)]
	[InlineData("qe", "", false)]
	[InlineData("", "3D", true)]
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
			subject.ReferenceIdentification2 = "6";
			subject.StateOrProvinceCode2 = "h7";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8";
			subject.CountryCode = "3D";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "Q";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "e";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("in", "6", true)]
	[InlineData("in", "", false)]
	[InlineData("", "6", true)]
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
			subject.ReferenceIdentification2 = "6";
			subject.StateOrProvinceCode2 = "h7";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8";
			subject.CountryCode = "3D";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "Q";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "e";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q", 4, true)]
	[InlineData("Q", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredMeasurementUnitQualifier(string measurementUnitQualifier, decimal height, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		if (height > 0) 
			subject.Height = height;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "6";
			subject.StateOrProvinceCode2 = "h7";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8";
			subject.CountryCode = "3D";
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "e";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 2, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.ReferenceIdentification2 = "6";
			subject.StateOrProvinceCode2 = "h7";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8";
			subject.CountryCode = "3D";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "Q";
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
