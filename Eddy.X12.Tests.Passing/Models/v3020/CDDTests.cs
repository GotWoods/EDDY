using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDD*nH*s*L*D*0*k*5*dJ*7*4Rm*5*lgg*4";

		var expected = new CDD_CreditDebitAdjustmentDetail()
		{
			AdjustmentReasonCode = "nH",
			CreditDebitFlagCode = "s",
			AssignedIdentification = "L",
			Amount = "D",
			ReturnFlagCode = "0",
			PriceBracketIdentifier = "k",
			CreditDebitQuantity = 5,
			UnitOfMeasurementCode = "dJ",
			UnitPriceDifference = 7,
			PriceIdentifierCode = "4Rm",
			UnitPrice = 5,
			PriceIdentifierCode2 = "lgg",
			UnitPrice2 = 4,
		};

		var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nH", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//At Least one
		subject.Amount = "D";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "4Rm";
			subject.UnitPrice = 5;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "lgg";
			subject.UnitPrice2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "nH";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//At Least one
		subject.Amount = "D";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "4Rm";
			subject.UnitPrice = 5;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "lgg";
			subject.UnitPrice2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("D", 5, true)]
	[InlineData("D", 0, true)]
	[InlineData("", 5, true)]
	public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "nH";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.Amount = amount;
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "4Rm";
			subject.UnitPrice = 5;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "lgg";
			subject.UnitPrice2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4Rm", 5, true)]
	[InlineData("4Rm", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "nH";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "D";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "lgg";
			subject.UnitPrice2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lgg", 4, true)]
	[InlineData("lgg", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "nH";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.PriceIdentifierCode2 = priceIdentifierCode2;
		if (unitPrice2 > 0) 
			subject.UnitPrice2 = unitPrice2;
		//At Least one
		subject.Amount = "D";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "4Rm";
			subject.UnitPrice = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
