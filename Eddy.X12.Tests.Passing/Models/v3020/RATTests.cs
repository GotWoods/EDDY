using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT*mC*9*dw*7*4*7*kn*4*Zr*2*h*8*9*4*Q*t";

		var expected = new RAT_AdjustableRateDescription()
		{
			UnitOfMeasurementCode = "mC",
			Quantity = 9,
			SourceOfInterestRateChangeCode = "dw",
			Percent = 7,
			Percent2 = 4,
			Percent3 = 7,
			UnitOfMeasurementCode2 = "kn",
			Quantity2 = 4,
			UnitOfMeasurementCode3 = "Zr",
			Quantity3 = 2,
			YesNoConditionOrResponseCode = "h",
			Percent4 = 8,
			Percent5 = 9,
			Percent6 = 4,
			RoundingSystemCode = "Q",
			RateLifeCapSourceCode = "t",
		};

		var actual = Map.MapObject<RAT_AdjustableRateDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mC", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dw", true)]
	public void Validation_RequiredSourceOfInterestRateChangeCode(string sourceOfInterestRateChangeCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.SourceOfInterestRateChangeCode = sourceOfInterestRateChangeCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredPercent2(decimal percent2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent2 > 0) 
			subject.Percent2 = percent2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
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
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent3 > 0) 
			subject.Percent3 = percent3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kn", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.Quantity2 = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
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
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Zr", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Zr", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Q", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Q", false)]
	public void Validation_AllAreRequiredPercent6(decimal percent6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		if (percent6 > 0) 
			subject.Percent6 = percent6;
		subject.RoundingSystemCode = roundingSystemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t", 8, true)]
	[InlineData("t", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percent4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.UnitOfMeasurementCode = "mC";
		subject.Quantity = 9;
		subject.SourceOfInterestRateChangeCode = "dw";
		subject.Percent = 7;
		subject.Percent2 = 4;
		subject.Percent3 = 7;
		subject.UnitOfMeasurementCode2 = "kn";
		subject.Quantity2 = 4;
		//Test Parameters
		subject.RateLifeCapSourceCode = rateLifeCapSourceCode;
		if (percent4 > 0) 
			subject.Percent4 = percent4;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
