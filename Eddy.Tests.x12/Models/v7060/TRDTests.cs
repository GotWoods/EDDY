using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060;

public class TRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRD*3*Tn**1**pG*rp*U*5**9*5*8coD*8**bRyp*2*";

		var expected = new TRD_TradeItemIngredientDetails()
		{
			MeasurementQualifier = "3",
			ReferenceIdentificationQualifier = "Tn",
			CompositeIngredientInformation = null,
			MeasurementValue = 1,
			CompositeUnitOfMeasure = null,
			PrecursorStatus = "pG",
			AgencyQualifierCode = "rp",
			ProductDescriptionCode = "U",
			MeasurementValue2 = 5,
			CompositeUnitOfMeasure2 = null,
			YesNoConditionOrResponseCode = "9",
			MeasurementValue3 = 5,
			ControlledDrug = "8coD",
			MeasurementValue4 = 8,
			CompositeUnitOfMeasure3 = null,
			Narcotic = "bRyp",
			MeasurementValue5 = 2,
			CompositeUnitOfMeasure4 = null,
		};

		var actual = Map.MapObject<TRD_TradeItemIngredientDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		//If one filled, all required
		if(subject.MeasurementValue4 > 0 || subject.MeasurementValue4 > 0 || subject.MeasurementValue4 != null)
		{
			subject.MeasurementValue4 = 8;
			subject.CompositeUnitOfMeasure3 = new C001_CompositeUnitOfMeasure();
		}
		if(subject.MeasurementValue5 > 0 || subject.MeasurementValue5 > 0 || subject.MeasurementValue5 != null)
		{
			subject.MeasurementValue5 = 2;
			subject.CompositeUnitOfMeasure4 = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "A", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredMeasurementValue4(decimal measurementValue4, string compositeUnitOfMeasure3, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "3";
		//Test Parameters
		if (measurementValue4 > 0) 
			subject.MeasurementValue4 = measurementValue4;
		if (compositeUnitOfMeasure3 != "") 
			subject.CompositeUnitOfMeasure3 = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.MeasurementValue5 > 0 || subject.MeasurementValue5 > 0 || subject.MeasurementValue5 != null)
		{
			subject.MeasurementValue5 = 2;
			subject.CompositeUnitOfMeasure4 = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "A", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredMeasurementValue5(decimal measurementValue5, string compositeUnitOfMeasure4, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "3";
		//Test Parameters
		if (measurementValue5 > 0) 
			subject.MeasurementValue5 = measurementValue5;
		if (compositeUnitOfMeasure4 != "") 
			subject.CompositeUnitOfMeasure4 = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.MeasurementValue4 > 0 || subject.MeasurementValue4 > 0 || subject.MeasurementValue4 != null)
		{
			subject.MeasurementValue4 = 8;
			subject.CompositeUnitOfMeasure3 = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
