using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDD*Hp*b*8*C*S*q*4*7I*7*Dke*1*DXn*6";

		var expected = new CDD_CreditDebitAdjustmentDetail()
		{
			AdjustmentReasonCode = "Hp",
			CreditDebitFlagCode = "b",
			AssignedIdentification = "8",
			Amount = "C",
			ReturnFlagCode = "S",
			PriceBracketIdentifier = "q",
			CreditDebitQuantity = 4,
			UnitOrBasisForMeasurementCode = "7I",
			UnitPriceDifference = 7,
			PriceIdentifierCode = "Dke",
			UnitPrice = 1,
			PriceIdentifierCode2 = "DXn",
			UnitPrice2 = 6,
		};

		var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hp", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.CreditDebitFlagCode = "b";
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//At Least one
		subject.Amount = "C";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "Dke";
			subject.UnitPrice = 1;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "DXn";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Hp";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//At Least one
		subject.Amount = "C";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "Dke";
			subject.UnitPrice = 1;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "DXn";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("C", 4, true)]
	[InlineData("C", 0, true)]
	[InlineData("", 4, true)]
	public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Hp";
		subject.CreditDebitFlagCode = "b";
		//Test Parameters
		subject.Amount = amount;
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "Dke";
			subject.UnitPrice = 1;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "DXn";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Dke", 1, true)]
	[InlineData("Dke", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Hp";
		subject.CreditDebitFlagCode = "b";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "C";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "DXn";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("DXn", 6, true)]
	[InlineData("DXn", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "Hp";
		subject.CreditDebitFlagCode = "b";
		//Test Parameters
		subject.PriceIdentifierCode2 = priceIdentifierCode2;
		if (unitPrice2 > 0) 
			subject.UnitPrice2 = unitPrice2;
		//At Least one
		subject.Amount = "C";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "Dke";
			subject.UnitPrice = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
