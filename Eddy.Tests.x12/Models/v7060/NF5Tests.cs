using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF5*3*3*JZ*cs*5*";

		var expected = new NF5_NutritionFactsPanelFats()
		{
			MeasurementQualifier = "3",
			MeasurementValue = 3,
			UnitOrBasisForMeasurementCode = "JZ",
			MeasurementSignificanceCode = "cs",
			MeasurementValue2 = 5,
			CompositeMultipleLanguageTextInformation = null,
		};

		var actual = Map.MapObject<NF5_NutritionFactsPanelFats>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		//Required fields
		subject.MeasurementValue = 3;
		subject.UnitOrBasisForMeasurementCode = "JZ";
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		//Required fields
		subject.MeasurementQualifier = "3";
		subject.UnitOrBasisForMeasurementCode = "JZ";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JZ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF5_NutritionFactsPanelFats();
		//Required fields
		subject.MeasurementQualifier = "3";
		subject.MeasurementValue = 3;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
