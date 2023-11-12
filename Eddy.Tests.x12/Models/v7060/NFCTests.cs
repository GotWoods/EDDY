using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NFCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NFC*X*5*Hx*Pj";

		var expected = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts()
		{
			MeasurementQualifier = "X",
			MeasurementValue = 5,
			UnitOrBasisForMeasurementCode = "Hx",
			MeasurementSignificanceCode = "Pj",
		};

		var actual = Map.MapObject<NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts();
		//Required fields
		subject.MeasurementValue = 5;
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts();
		//Required fields
		subject.MeasurementQualifier = "X";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
