using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF8*Q*1*4*Ty*Jg";

		var expected = new NF8_NutritionFactsPanelVitaminsAndMinerals()
		{
			MeasurementQualifier = "Q",
			MeasurementValue = 1,
			MeasurementValue2 = 4,
			UnitOrBasisForMeasurementCode = "Ty",
			MeasurementSignificanceCode = "Jg",
		};

		var actual = Map.MapObject<NF8_NutritionFactsPanelVitaminsAndMinerals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		subject.MeasurementValue = 1;
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		subject.MeasurementQualifier = "Q";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "Ty", true)]
	[InlineData(0, "Ty", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredMeasurementValue2(decimal measurementValue2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		subject.MeasurementQualifier = "Q";
		subject.MeasurementValue = 1;
		if (measurementValue2 > 0)
		subject.MeasurementValue2 = measurementValue2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
