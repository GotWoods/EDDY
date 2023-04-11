using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HSD*nl*4*8E*4*R*3*W*N*9*T";

		var expected = new HSD_HealthCareServicesDelivery()
		{
			QuantityQualifier = "nl",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "8E",
			SampleSelectionModulus = 4,
			TimePeriodQualifier = "R",
			NumberOfPeriods = 3,
			ShipDeliveryOrCalendarPatternCode = "W",
			ShipDeliveryPatternTimeCode = "N",
			NumberOfPeriods2 = 9,
			Description = "T",
		};

		var actual = Map.MapObject<HSD_HealthCareServicesDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("nl", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("nl", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "R", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		subject.TimePeriodQualifier = timePeriodQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "R", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBNumberOfPeriods2(int numberOfPeriods2, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new HSD_HealthCareServicesDelivery();
		if (numberOfPeriods2 > 0)
		subject.NumberOfPeriods2 = numberOfPeriods2;
		subject.TimePeriodQualifier = timePeriodQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
