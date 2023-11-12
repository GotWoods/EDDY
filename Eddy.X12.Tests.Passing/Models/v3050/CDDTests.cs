using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDD*m3*s*M*s*W*n*9*6o*6*JMm*7*ocX*5";

		var expected = new CDD_CreditDebitAdjustmentDetail()
		{
			AdjustmentReasonCode = "m3",
			CreditDebitFlagCode = "s",
			AssignedIdentification = "M",
			Amount = "s",
			YesNoConditionOrResponseCode = "W",
			PriceBracketIdentifier = "n",
			CreditDebitQuantity = 9,
			UnitOrBasisForMeasurementCode = "6o",
			UnitPriceDifference = 6,
			PriceIdentifierCode = "JMm",
			UnitPrice = 7,
			PriceIdentifierCode2 = "ocX",
			UnitPrice2 = 5,
		};

		var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m3", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//At Least one
		subject.Amount = "s";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "6o";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
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
		subject.AdjustmentReasonCode = "m3";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//At Least one
		subject.Amount = "s";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "6o";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("s", 9, true)]
	[InlineData("s", 0, true)]
	[InlineData("", 9, true)]
	public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "m3";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.Amount = amount;
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		//A Requires B
		if (creditDebitQuantity > 0)
			subject.UnitPrice = 7;
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "6o";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "6o", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "6o", false)]
	public void Validation_AllAreRequiredCreditDebitQuantity(decimal creditDebitQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "m3";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.Amount = "s";

        if (subject.CreditDebitQuantity != null)
            subject.UnitPrice = 7;

		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 7, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 7, true)]
	public void Validation_ARequiresBCreditDebitQuantity(decimal creditDebitQuantity, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "m3";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "s";


        if (subject.CreditDebitQuantity != null)
            subject.UnitOrBasisForMeasurementCode = "SA";

		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("JMm", 7, true)]
	[InlineData("JMm", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "m3";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "s";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "6o";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "ocX";
			subject.UnitPrice2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ocX", 5, true)]
	[InlineData("ocX", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "m3";
		subject.CreditDebitFlagCode = "s";
		//Test Parameters
		subject.PriceIdentifierCode2 = priceIdentifierCode2;
		if (unitPrice2 > 0) 
			subject.UnitPrice2 = unitPrice2;
		//At Least one
		subject.Amount = "s";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 9;
			subject.UnitOrBasisForMeasurementCode = "6o";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "JMm";
			subject.UnitPrice = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
