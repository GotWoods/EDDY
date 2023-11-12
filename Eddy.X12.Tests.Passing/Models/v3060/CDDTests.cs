using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDD*cW*y*9*y*d*g*7*jG*1*IEb*7*60I*6";

		var expected = new CDD_CreditDebitAdjustmentDetail()
		{
			AdjustmentReasonCode = "cW",
			CreditDebitFlagCode = "y",
			AssignedIdentification = "9",
			Amount = "y",
			YesNoConditionOrResponseCode = "d",
			PriceBracketIdentifier = "g",
			CreditDebitQuantity = 7,
			UnitOrBasisForMeasurementCode = "jG",
			UnitPriceDifference = 1,
			PriceIdentifierCode = "IEb",
			UnitPrice = 7,
			PriceIdentifierCode2 = "60I",
			UnitPrice2 = 6,
		};

		var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cW", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.CreditDebitFlagCode = "y";
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		//At Least one
		subject.Amount = "y";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 7;
			subject.UnitOrBasisForMeasurementCode = "jG";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		//Test Parameters
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//At Least one
		subject.Amount = "y";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 7;
			subject.UnitOrBasisForMeasurementCode = "jG";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("y", 7, true)]
	[InlineData("y", 0, true)]
	[InlineData("", 7, true)]
	public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		subject.CreditDebitFlagCode = "y";
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
			subject.CreditDebitQuantity = 7;
			subject.UnitOrBasisForMeasurementCode = "jG";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "jG", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "jG", false)]
	public void Validation_AllAreRequiredCreditDebitQuantity(decimal creditDebitQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		subject.CreditDebitFlagCode = "y";
		//Test Parameters
        if (creditDebitQuantity > 0)
        {
            subject.CreditDebitQuantity = creditDebitQuantity;
			subject.UnitPrice = 6;
        }

        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.Amount = "y";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 7, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 7, true)]
	public void Validation_ARequiresBCreditDebitQuantity(decimal creditDebitQuantity, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		subject.CreditDebitFlagCode = "y";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;

        if (subject.CreditDebitQuantity != null)
            subject.UnitOrBasisForMeasurementCode = "SA";

        //At Least one
        subject.Amount = "y";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("IEb", 7, true)]
	[InlineData("IEb", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		subject.CreditDebitFlagCode = "y";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//At Least one
		subject.Amount = "y";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 7;
			subject.UnitOrBasisForMeasurementCode = "jG";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode2) || !string.IsNullOrEmpty(subject.PriceIdentifierCode2) || subject.UnitPrice2 > 0)
		{
			subject.PriceIdentifierCode2 = "60I";
			subject.UnitPrice2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("60I", 6, true)]
	[InlineData("60I", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
	{
		var subject = new CDD_CreditDebitAdjustmentDetail();
		//Required fields
		subject.AdjustmentReasonCode = "cW";
		subject.CreditDebitFlagCode = "y";
		//Test Parameters
		subject.PriceIdentifierCode2 = priceIdentifierCode2;
		if (unitPrice2 > 0) 
			subject.UnitPrice2 = unitPrice2;
		//At Least one
		subject.Amount = "y";
		//If one filled, all required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 7;
			subject.UnitOrBasisForMeasurementCode = "jG";
		}
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "IEb";
			subject.UnitPrice = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
