using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*T*Pz*n*g7*y*l*Qk*15*aD*d5*h*q*A*2*B*9*t*fi";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceIdentification = "T",
			StateOrProvinceCode = "Pz",
			ReferenceIdentification2 = "n",
			StateOrProvinceCode2 = "g7",
			ApplicantTypeCode = "y",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "l",
			CountryCode = "Qk",
			LanguageCode = "15",
			StatusCode = "aD",
			CityName = "d5",
			Color = "h",
			Color2 = "q",
			MeasurementUnitQualifier = "A",
			Height = 2,
			WeightUnitCode = "B",
			Weight = 9,
			Description = "t",
			CountryCode2 = "fi",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("n", "g7", true)]
	[InlineData("", "g7", false)]
	[InlineData("n", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("l", "Qk", true)]
	[InlineData("", "Qk", false)]
	[InlineData("l", "", false)]
	public void Validation_AllAreRequiredCodeForLicensingCertificationRegistrationOrAccreditationAgency(string codeForLicensingCertificationRegistrationOrAccreditationAgency, string countryCode, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = codeForLicensingCertificationRegistrationOrAccreditationAgency;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Qk", true)]
	[InlineData("15", "", false)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string countryCode, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.LanguageCode = languageCode;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "n", true)]
	[InlineData("aD", "", false)]
	public void Validation_ARequiresBStatusCode(string statusCode, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.StatusCode = statusCode;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("A", 2, true)]
	[InlineData("", 2, false)]
	[InlineData("A", 0, false)]
	public void Validation_AllAreRequiredMeasurementUnitQualifier(string measurementUnitQualifier, decimal height, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		if (height > 0)
		subject.Height = height;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("B", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("B", 0, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
