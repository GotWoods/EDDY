using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF8*A*4*4*Y3*ou";

		var expected = new NF8_NutritionFactsPanelVitaminsAndMinerals()
		{
			MeasurementQualifier = "A",
			MeasurementValue = 4,
			MeasurementValue2 = 4,
			UnitOrBasisForMeasurementCode = "Y3",
			MeasurementSignificanceCode = "ou",
		};

		var actual = Map.MapObject<NF8_NutritionFactsPanelVitaminsAndMinerals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		//Required fields
		subject.MeasurementValue = 4;
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		//If one filled, all required
		if(subject.MeasurementValue2 > 0 || subject.MeasurementValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue2 = 4;
			subject.UnitOrBasisForMeasurementCode = "Y3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		//Required fields
		subject.MeasurementQualifier = "A";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(subject.MeasurementValue2 > 0 || subject.MeasurementValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue2 = 4;
			subject.UnitOrBasisForMeasurementCode = "Y3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Y3", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Y3", false)]
	public void Validation_AllAreRequiredMeasurementValue2(decimal measurementValue2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF8_NutritionFactsPanelVitaminsAndMinerals();
		//Required fields
		subject.MeasurementQualifier = "A";
		subject.MeasurementValue = 4;
		//Test Parameters
		if (measurementValue2 > 0) 
			subject.MeasurementValue2 = measurementValue2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
