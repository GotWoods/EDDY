using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF7*6*6*bn*il*1";

		var expected = new NF7_NutritionFactsPanelOtherNutrients()
		{
			MeasurementQualifier = "6",
			MeasurementValue = 6,
			UnitOrBasisForMeasurementCode = "bn",
			MeasurementSignificanceCode = "il",
			MeasurementValue2 = 1,
		};

		var actual = Map.MapObject<NF7_NutritionFactsPanelOtherNutrients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		subject.MeasurementValue = 6;
		subject.UnitOrBasisForMeasurementCode = "bn";
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		subject.MeasurementQualifier = "6";
		subject.UnitOrBasisForMeasurementCode = "bn";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bn", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		subject.MeasurementQualifier = "6";
		subject.MeasurementValue = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
