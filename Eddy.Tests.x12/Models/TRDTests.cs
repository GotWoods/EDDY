using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class TRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRD*6*cD**6**VG*am*k*7**I*2*nRSB*8**34ej*9*";

		var expected = new TRD_TradeItemIngredientDetails()
		{
			MeasurementQualifier = "6",
			ReferenceIdentificationQualifier = "cD",
			CompositeIngredientInformation = null,
			MeasurementValue = 6,
			CompositeUnitOfMeasure = null,
			PrecursorStatus = "VG",
			AgencyQualifierCode = "am",
			ProductDescriptionCode = "k",
			MeasurementValue2 = 7,
			CompositeUnitOfMeasure2 = null,
			YesNoConditionOrResponseCode = "I",
			MeasurementValue3 = 2,
			ControlledDrug = "nRSB",
			MeasurementValue4 = 8,
			CompositeUnitOfMeasure3 = null,
			Narcotic = "34ej",
			MeasurementValue5 = 9,
			CompositeUnitOfMeasure4 = null,
		};

		var actual = Map.MapObject<TRD_TradeItemIngredientDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredMeasurementValue4(decimal measurementValue4, string compositeUnitOfMeasure3, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		subject.MeasurementQualifier = "6";
		if (measurementValue4 > 0)
		subject.MeasurementValue4 = measurementValue4;
        if (compositeUnitOfMeasure3 != "")
            subject.CompositeUnitOfMeasure3 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure3 };


		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredMeasurementValue5(decimal measurementValue5, string compositeUnitOfMeasure4, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		subject.MeasurementQualifier = "6";
		if (measurementValue5 > 0)
		subject.MeasurementValue5 = measurementValue5;
		
        if (compositeUnitOfMeasure4 != "")
            subject.CompositeUnitOfMeasure4 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure4 };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
