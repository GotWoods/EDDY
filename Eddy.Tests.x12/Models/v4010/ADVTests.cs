using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ADVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADV*xZ*ZJ*8*7*0*Bb*2";

		var expected = new ADV_AdvertisingDemographicInformation()
		{
			AgencyQualifierCode = "xZ",
			ServiceCharacteristicsQualifier = "ZJ",
			RangeMinimum = 8,
			RangeMaximum = 7,
			Category = "0",
			ServiceCharacteristicsQualifier2 = "Bb",
			MeasurementValue = 2,
		};

		var actual = Map.MapObject<ADV_AdvertisingDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xZ", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "ZJ";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || subject.MeasurementValue > 0)
		{
			subject.ServiceCharacteristicsQualifier2 = "Bb";
			subject.MeasurementValue = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZJ", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.AgencyQualifierCode = "xZ";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || subject.MeasurementValue > 0)
		{
			subject.ServiceCharacteristicsQualifier2 = "Bb";
			subject.MeasurementValue = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Bb", 2, true)]
	[InlineData("Bb", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, decimal measurementValue, bool isValidExpected)
	{
		var subject = new ADV_AdvertisingDemographicInformation();
		//Required fields
		subject.AgencyQualifierCode = "xZ";
		subject.ServiceCharacteristicsQualifier = "ZJ";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
