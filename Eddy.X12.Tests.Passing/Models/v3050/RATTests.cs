using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT*Uu*6*ij*5*3*7*sa*4*MI*7*f*4*7*3*g*J";

		var expected = new RAT_AdjustableRateDescription()
		{
			UnitOrBasisForMeasurementCode = "Uu",
			Quantity = 6,
			SourceOfInterestRateChangeCode = "ij",
			Percent = 5,
			Percent2 = 3,
			Percent3 = 7,
			UnitOrBasisForMeasurementCode2 = "sa",
			Quantity2 = 4,
			UnitOrBasisForMeasurementCode3 = "MI",
			Quantity3 = 7,
			YesNoConditionOrResponseCode = "f",
			Percent4 = 4,
			Percent5 = 7,
			Percent6 = 3,
			RoundingSystemCode = "g",
			RateLifeCapSourceCode = "J",
		};

		var actual = Map.MapObject<RAT_AdjustableRateDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uu", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ij", true)]
	public void Validation_RequiredSourceOfInterestRateChangeCode(string sourceOfInterestRateChangeCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.SourceOfInterestRateChangeCode = sourceOfInterestRateChangeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPercent2(decimal percent2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent2 > 0) 
			subject.Percent2 = percent2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPercent3(decimal percent3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent3 > 0) 
			subject.Percent3 = percent3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sa", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.Quantity2 = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MI", 7, true)]
	[InlineData("MI", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "g", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "g", false)]
	public void Validation_AllAreRequiredPercent6(decimal percent6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent6 > 0) 
			subject.Percent6 = percent6;
		subject.RoundingSystemCode = roundingSystemCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("J", 4, true)]
	[InlineData("J", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percent4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Uu";
		subject.Quantity = 6;
		subject.SourceOfInterestRateChangeCode = "ij";
		subject.Percent = 5;
		subject.Percent2 = 3;
		subject.Percent3 = 7;
		subject.UnitOrBasisForMeasurementCode2 = "sa";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.RateLifeCapSourceCode = rateLifeCapSourceCode;
		if (percent4 > 0) 
			subject.Percent4 = percent4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Quantity3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "MI";
			subject.Quantity3 = 7;
		}
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 3;
			subject.RoundingSystemCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
