using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDD*Lq*1*8*z*t*H*8*Od*2*zX9*7*yfk*6";

		var expected = new CDD_CreditDebitAdjustmentDetail()
		{
			AdjustmentReasonCode = "Lq",
			CreditDebitFlagCode = "1",
			AssignedIdentification = "8",
			Amount = "z",
			ReturnFlagCode = "t",
			PriceBracketIdentifier = "H",
			CreditDebitQuantity = 8,
			UnitOrBasisForMeasurementCode = "Od",
			UnitPriceDifference = 2,
			PriceIdentifierCode = "zX9",
			UnitPrice = 7,
			PriceIdentifierCode2 = "yfk",
			UnitPrice2 = 6,
		};

		var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lq", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.CreditDebitFlagCode = "1";
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//At Least one
		subject.Amount = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "zX9";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "yfk";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Lq";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//At Least one
		subject.Amount = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "zX9";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "yfk";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("z", 8, true)]
	[InlineData("z", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Lq";
		subject.CreditDebitFlagCode = "1";
		//Test Parameters
		subject.Amount = amount;
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "zX9";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "yfk";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("zX9", 7, true)]
	[InlineData("zX9", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Lq";
		subject.CreditDebitFlagCode = "1";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "yfk";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("yfk", 6, true)]
	[InlineData("yfk", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Lq";
		subject.CreditDebitFlagCode = "1";
		//Test Parameters
		subject.PriceIdentifierCode2 = priceIdentifierCode2;
		if (unitPrice2 > 0) 
			subject.UnitPrice2 = unitPrice2;
		//At Least one
		subject.Amount = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "zX9";
			subject.UnitPrice = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
