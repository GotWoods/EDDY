using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF6*R*1*Ov*0H*3";

		var expected = new NF6_NutritionFactsPanelCarbohydrates()
		{
			MeasurementQualifier = "R",
			MeasurementValue = 1,
			UnitOrBasisForMeasurementCode = "Ov",
			MeasurementSignificanceCode = "0H",
			MeasurementValue2 = 3,
		};

		var actual = Map.MapObject<NF6_NutritionFactsPanelCarbohydrates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		subject.MeasurementValue = 1;
		subject.UnitOrBasisForMeasurementCode = "Ov";
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		subject.MeasurementQualifier = "R";
		subject.UnitOrBasisForMeasurementCode = "Ov";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ov", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		subject.MeasurementQualifier = "R";
		subject.MeasurementValue = 1;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
