using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NFCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NFC*O*4*6x*Q7";

		var expected = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts()
		{
			MeasurementQualifier = "O",
			MeasurementValue = 4,
			UnitOrBasisForMeasurementCode = "6x",
			MeasurementSignificanceCode = "Q7",
		};

		var actual = Map.MapObject<NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts();
		subject.MeasurementValue = 4;
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NFC_NutritionFactsPanelFooterCalorieDietNutrientAmounts();
		subject.MeasurementQualifier = "O";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
