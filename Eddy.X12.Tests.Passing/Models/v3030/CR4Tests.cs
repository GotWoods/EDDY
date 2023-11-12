using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR4*Y*x*1b*6*JY*7*K*UN*4*QB*5*LI*2*5*Y*0*I*9*5*E*2*3*6*9*2*7*3*5*J";

		var expected = new CR4_EnteralOrParenteralTherapyCertification()
		{
			YesNoConditionOrResponseCode = "Y",
			CertificationTypeCode = "x",
			UnitOrBasisForMeasurementCode = "1b",
			Quantity = 6,
			UnitOrBasisForMeasurementCode2 = "JY",
			Quantity2 = 7,
			NonVisitCode = "K",
			UnitOrBasisForMeasurementCode3 = "UN",
			Quantity3 = 4,
			UnitOrBasisForMeasurementCode4 = "QB",
			Height = 5,
			UnitOrBasisForMeasurementCode5 = "LI",
			Weight = 2,
			Quantity4 = 5,
			Description = "Y",
			NutrientAdministrationMethodCode = "0",
			NutrientAdministrationTechniqueCode = "I",
			Quantity5 = 9,
			Quantity6 = 5,
			Description2 = "E",
			Quantity7 = 2,
			Percent = 3,
			Quantity8 = 6,
			Quantity9 = 9,
			Percent2 = 2,
			Quantity10 = 7,
			Percent3 = 3,
			Quantity11 = 5,
			Description3 = "J",
		};

		var actual = Map.MapObject<CR4_EnteralOrParenteralTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "UN";
			subject.Quantity3 = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "QB";
			subject.Height = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "LI";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("UN", 4, true)]
	[InlineData("UN", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "Y";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "QB";
			subject.Height = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "LI";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("QB", 5, true)]
	[InlineData("QB", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal height, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "Y";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (height > 0) 
			subject.Height = height;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "UN";
			subject.Quantity3 = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "LI";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("LI", 2, true)]
	[InlineData("LI", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal weight, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "Y";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "UN";
			subject.Quantity3 = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "QB";
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
