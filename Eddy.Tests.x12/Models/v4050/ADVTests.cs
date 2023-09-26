using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ADVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADV*nb*3x*8*2*O*Jh*7";

		var expected = new ADV_AdvertisingDemographicInformation()
		{
			AgencyQualifierCode = "nb",
			ServiceCharacteristicsQualifier = "3x",
			RangeMinimum = 8,
			RangeMaximum = 2,
			Category = "O",
			ServiceCharacteristicsQualifier2 = "Jh",
			MeasurementValue = 7,
		};

		var actual = Map.MapObject<ADV_AdvertisingDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nb", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "3x";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || subject.MeasurementValue > 0)
		{
			subject.ServiceCharacteristicsQualifier2 = "Jh";
			subject.MeasurementValue = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3x", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.AgencyQualifierCode = "nb";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || subject.MeasurementValue > 0)
		{
			subject.ServiceCharacteristicsQualifier2 = "Jh";
			subject.MeasurementValue = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Jh", 7, true)]
	[InlineData("Jh", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, decimal measurementValue, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.AgencyQualifierCode = "nb";
		subject.ServiceCharacteristicsQualifier = "3x";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
