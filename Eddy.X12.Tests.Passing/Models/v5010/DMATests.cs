using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*I*8V*N*Ny*S*s*Rp*LX*ZY*rG*A*a*V*1*S*5*l*Vy";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "I",
			StateOrProvinceCode = "8V",
			ReferenceIdentification2 = "N",
			StateOrProvinceCode2 = "Ny",
			ApplicantTypeCode = "S",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s",
			CountryCode = "Rp",
			LanguageCode = "LX",
			StatusCode = "ZY",
			CityName = "rG",
			Color = "A",
			Color2 = "a",
			MeasurementUnitQualifier = "V",
			Height = 1,
			WeightUnitCode = "S",
			Weight = 5,
			Description = "l",
			CountryCode2 = "Vy",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "Ny", true)]
	[InlineData("N", "", false)]
	[InlineData("", "Ny", false)]
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
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s";
			subject.CountryCode = "Rp";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "V";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "S";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "Rp", true)]
	[InlineData("s", "", false)]
	[InlineData("", "Rp", false)]
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
			subject.ReferenceIdentification2 = "N";
			subject.StateOrProvinceCode2 = "Ny";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "V";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "S";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LX", "Rp", true)]
	[InlineData("LX", "", false)]
	[InlineData("", "Rp", true)]
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
			subject.ReferenceIdentification2 = "N";
			subject.StateOrProvinceCode2 = "Ny";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s";
			subject.CountryCode = "Rp";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "V";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "S";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZY", "N", true)]
	[InlineData("ZY", "", false)]
	[InlineData("", "N", true)]
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
			subject.ReferenceIdentification2 = "N";
			subject.StateOrProvinceCode2 = "Ny";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s";
			subject.CountryCode = "Rp";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "V";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "S";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("V", 1, true)]
	[InlineData("V", 0, false)]
	[InlineData("", 1, false)]
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
			subject.ReferenceIdentification2 = "N";
			subject.StateOrProvinceCode2 = "Ny";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s";
			subject.CountryCode = "Rp";
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "S";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("S", 5, true)]
	[InlineData("S", 0, false)]
	[InlineData("", 5, false)]
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
			subject.ReferenceIdentification2 = "N";
			subject.StateOrProvinceCode2 = "Ny";
		}
		if(!string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "s";
			subject.CountryCode = "Rp";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "V";
			subject.Height = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
