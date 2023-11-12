using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF6*7*2*vK*Ep*2";

		var expected = new NF6_NutritionFactsPanelCarbohydrates()
		{
			MeasurementQualifier = "7",
			MeasurementValue = 2,
			UnitOrBasisForMeasurementCode = "vK",
			MeasurementSignificanceCode = "Ep",
			MeasurementValue2 = 2,
		};

		var actual = Map.MapObject<NF6_NutritionFactsPanelCarbohydrates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		//Required fields
		subject.MeasurementValue = 2;
		subject.UnitOrBasisForMeasurementCode = "vK";
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		//Required fields
		subject.MeasurementQualifier = "7";
		subject.UnitOrBasisForMeasurementCode = "vK";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vK", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF6_NutritionFactsPanelCarbohydrates();
		//Required fields
		subject.MeasurementQualifier = "7";
		subject.MeasurementValue = 2;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
