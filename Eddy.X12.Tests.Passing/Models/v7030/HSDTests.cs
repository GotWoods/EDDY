using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class HSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HSD*6S*4*nB*8*x*6*9*i*8*l";

		var expected = new HSD_HealthCareServicesDelivery()
		{
			QuantityQualifier = "6S",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "nB",
			SampleSelectionModulus = 8,
			TimePeriodQualifier = "x",
			NumberOfPeriods = 6,
			ShipDeliveryOrCalendarPatternCode = "9",
			ShipDeliveryPatternTimeCode = "i",
			NumberOfPeriods2 = 8,
			Description = "l",
		};

		var actual = Map.MapObject<HSD_HealthCareServicesDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6S", 4, true)]
	[InlineData("6S", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		//Required fields
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "x", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		//Required fields
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "6S";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "x", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBNumberOfPeriods2(int numberOfPeriods2, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		//Required fields
		//Test Parameters
		if (numberOfPeriods2 > 0) 
			subject.NumberOfPeriods2 = numberOfPeriods2;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "6S";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
