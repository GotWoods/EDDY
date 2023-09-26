using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR4*k*N*gp*8*7J*8*E*3z*7*27*9*dR*7*4*c*L*2*4*8*X*9*4*3*1*3*8*4*7*p";

		var expected = new CR4_EnteralOrParenteralTherapyCertification()
		{
			YesNoConditionOrResponseCode = "k",
			CertificationTypeCode = "N",
			UnitOrBasisForMeasurementCode = "gp",
			Quantity = 8,
			UnitOrBasisForMeasurementCode2 = "7J",
			Quantity2 = 8,
			NonVisitCode = "E",
			UnitOrBasisForMeasurementCode3 = "3z",
			Quantity3 = 7,
			UnitOrBasisForMeasurementCode4 = "27",
			Height = 9,
			UnitOrBasisForMeasurementCode5 = "dR",
			Weight = 7,
			Quantity4 = 4,
			Description = "c",
			NutrientAdministrationMethodCode = "L",
			NutrientAdministrationTechniqueCode = "2",
			Quantity5 = 4,
			Quantity6 = 8,
			Description2 = "X",
			Quantity7 = 9,
			Percent = 4,
			Quantity8 = 3,
			Quantity9 = 1,
			Percent2 = 3,
			Quantity10 = 8,
			Percent3 = 4,
			Quantity11 = 7,
			Description3 = "p",
		};

		var actual = Map.MapObject<CR4_EnteralOrParenteralTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7J";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "3z";
			subject.Quantity3 = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "27";
			subject.Height = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "dR";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gp", 8, true)]
	[InlineData("gp", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7J";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "3z";
			subject.Quantity3 = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "27";
			subject.Height = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "dR";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7J", 8, true)]
	[InlineData("7J", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "3z";
			subject.Quantity3 = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "27";
			subject.Height = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "dR";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("3z", 7, true)]
	[InlineData("3z", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7J";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "27";
			subject.Height = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "dR";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("27", 9, true)]
	[InlineData("27", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal height, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (height > 0) 
			subject.Height = height;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7J";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "3z";
			subject.Quantity3 = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "dR";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("dR", 7, true)]
	[InlineData("dR", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal weight, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7J";
			subject.Quantity2 = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "3z";
			subject.Quantity3 = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "27";
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
