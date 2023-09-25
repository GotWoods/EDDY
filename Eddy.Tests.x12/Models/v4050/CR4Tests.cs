using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR4*r*4*nJ*9*U6*2*W*Sr*5*lr*4*Mh*9*6*Z*A*a*8*5*B*9*8*5*3*6*5*1*4*Z";

		var expected = new CR4_EnteralOrParenteralTherapyCertification()
		{
			YesNoConditionOrResponseCode = "r",
			CertificationTypeCode = "4",
			UnitOrBasisForMeasurementCode = "nJ",
			Quantity = 9,
			UnitOrBasisForMeasurementCode2 = "U6",
			Quantity2 = 2,
			NonVisitCode = "W",
			UnitOrBasisForMeasurementCode3 = "Sr",
			Quantity3 = 5,
			UnitOrBasisForMeasurementCode4 = "lr",
			Height = 4,
			UnitOrBasisForMeasurementCode5 = "Mh",
			Weight = 9,
			Quantity4 = 6,
			Description = "Z",
			NutrientAdministrationMethodCode = "A",
			NutrientAdministrationTechniqueCode = "a",
			Quantity5 = 8,
			Quantity6 = 5,
			Description2 = "B",
			Quantity7 = 9,
			PercentageAsDecimal = 8,
			Quantity8 = 5,
			Quantity9 = 3,
			PercentageAsDecimal2 = 6,
			Quantity10 = 5,
			PercentageAsDecimal3 = 1,
			Quantity11 = 4,
			Description3 = "Z",
		};

		var actual = Map.MapObject<CR4_EnteralOrParenteralTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "nJ";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "U6";
			subject.Quantity2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Sr";
			subject.Quantity3 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "lr";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "Mh";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("nJ", 9, true)]
	[InlineData("nJ", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "U6";
			subject.Quantity2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Sr";
			subject.Quantity3 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "lr";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "Mh";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U6", 2, true)]
	[InlineData("U6", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "nJ";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Sr";
			subject.Quantity3 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "lr";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "Mh";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Sr", 5, true)]
	[InlineData("Sr", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "nJ";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "U6";
			subject.Quantity2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "lr";
			subject.Height = 4;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "Mh";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lr", 4, true)]
	[InlineData("lr", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal height, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (height > 0) 
			subject.Height = height;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "nJ";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "U6";
			subject.Quantity2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Sr";
			subject.Quantity3 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "Mh";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Mh", 9, true)]
	[InlineData("Mh", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal weight, bool isValidExpected)
	{
		var subject = new CR4_EnteralOrParenteralTherapyCertification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "r";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "nJ";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "U6";
			subject.Quantity2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Sr";
			subject.Quantity3 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "lr";
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
