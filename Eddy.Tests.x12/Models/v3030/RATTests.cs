using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT*PC*1*pw*3*3*6*xU*3*P4*4*d*8*2*7*K*V";

		var expected = new RAT_AdjustableRateDescription()
		{
			UnitOrBasisForMeasurementCode = "PC",
			Quantity = 1,
			SourceOfInterestRateChangeCode = "pw",
			Percent = 3,
			Percent2 = 3,
			Percent3 = 6,
			UnitOrBasisForMeasurementCode2 = "xU",
			Quantity2 = 3,
			UnitOrBasisForMeasurementCode3 = "P4",
			Quantity3 = 4,
			YesNoConditionOrResponseCode = "d",
			Percent4 = 8,
			Percent5 = 2,
			Percent6 = 7,
			RoundingSystemCode = "K",
			RateLifeCapSourceCode = "V",
		};

		var actual = Map.MapObject<RAT_AdjustableRateDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PC", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pw", true)]
	public void Validation_RequiredSourceOfInterestRateChangeCode(string sourceOfInterestRateChangeCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		subject.SourceOfInterestRateChangeCode = sourceOfInterestRateChangeCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
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
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent2 > 0) 
			subject.Percent2 = percent2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredPercent3(decimal percent3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent3 > 0) 
			subject.Percent3 = percent3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xU", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.Quantity2 = 3;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "P4", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "P4", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "K", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "K", false)]
	public void Validation_AllAreRequiredPercent6(decimal percent6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent6 > 0) 
			subject.Percent6 = percent6;
		subject.RoundingSystemCode = roundingSystemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("V", 8, true)]
	[InlineData("V", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percent4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "PC";
		subject.Quantity = 1;
		subject.SourceOfInterestRateChangeCode = "pw";
		subject.Percent = 3;
		subject.Percent2 = 3;
		subject.Percent3 = 6;
		subject.UnitOrBasisForMeasurementCode2 = "xU";
		subject.Quantity2 = 3;
		//Test Parameters
		subject.RateLifeCapSourceCode = rateLifeCapSourceCode;
		if (percent4 > 0) 
			subject.Percent4 = percent4;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 7;
			subject.RoundingSystemCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
