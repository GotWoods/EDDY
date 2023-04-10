using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR4*Q*Z*Gl*7*xc*4*O*FA*9*Z6*6*JJ*9*1*S*q*D*5*3*Q*6*5*6*6*1*3*3*2*k";

		var expected = new CR4_EnteralOrParenteralTherapyCertification()
		{
			YesNoConditionOrResponseCode = "Q",
			CertificationTypeCode = "Z",
			UnitOrBasisForMeasurementCode = "Gl",
			Quantity = 7,
			UnitOrBasisForMeasurementCode2 = "xc",
			Quantity2 = 4,
			NonVisitCode = "O",
			UnitOrBasisForMeasurementCode3 = "FA",
			Quantity3 = 9,
			UnitOrBasisForMeasurementCode4 = "Z6",
			Height = 6,
			UnitOrBasisForMeasurementCode5 = "JJ",
			Weight = 9,
			Quantity4 = 1,
			Description = "S",
			NutrientAdministrationMethodCode = "q",
			NutrientAdministrationTechniqueCode = "D",
			Quantity5 = 5,
			Quantity6 = 3,
			Description2 = "Q",
			Quantity7 = 6,
			PercentageAsDecimal = 5,
			Quantity8 = 6,
			Quantity9 = 6,
			PercentageAsDecimal2 = 1,
			Quantity10 = 3,
			PercentageAsDecimal3 = 3,
			Quantity11 = 2,
			Description3 = "k",
		};

		var actual = Map.MapObject<CR4_EnteralOrParenteralTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Gl", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("Gl", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = "Q";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("xc", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("xc", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = "Q";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("FA", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("FA", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = "Q";
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Z6", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("Z6", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal height, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = "Q";
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (height > 0)
		subject.Height = height;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("JJ", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("JJ", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal weight, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		subject.YesNoConditionOrResponseCode = "Q";
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
