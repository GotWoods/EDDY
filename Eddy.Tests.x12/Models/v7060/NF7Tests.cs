using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF7*8*6*L7*Y4*8";

		var expected = new NF7_NutritionFactsPanelOtherNutrients()
		{
			MeasurementQualifier = "8",
			MeasurementValue = 6,
			UnitOrBasisForMeasurementCode = "L7",
			MeasurementSignificanceCode = "Y4",
			MeasurementValue2 = 8,
		};

		var actual = Map.MapObject<NF7_NutritionFactsPanelOtherNutrients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		//Required fields
		subject.MeasurementValue = 6;
		subject.UnitOrBasisForMeasurementCode = "L7";
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		//Required fields
		subject.MeasurementQualifier = "8";
		subject.UnitOrBasisForMeasurementCode = "L7";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L7", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF7_NutritionFactsPanelOtherNutrients();
		//Required fields
		subject.MeasurementQualifier = "8";
		subject.MeasurementValue = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
