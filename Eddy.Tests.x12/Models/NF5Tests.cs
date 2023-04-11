using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF5*4*2*ka*dQ*4*";

		var expected = new NF5_NutritionFactsPanelFats()
		{
			MeasurementQualifier = "4",
			MeasurementValue = 2,
			UnitOrBasisForMeasurementCode = "ka",
			MeasurementSignificanceCode = "dQ",
			MeasurementValue2 = 4,
			CompositeMultipleLanguageTextInformation = null,
		};

		var actual = Map.MapObject<NF5_NutritionFactsPanelFats>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		subject.MeasurementValue = 2;
		subject.UnitOrBasisForMeasurementCode = "ka";
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		subject.MeasurementQualifier = "4";
		subject.UnitOrBasisForMeasurementCode = "ka";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ka", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		subject.MeasurementQualifier = "4";
		subject.MeasurementValue = 2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
