using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G12*uG*1*4*F7*5*p3MSN1PzUxU8*gh*L*Z6*u*e*LD*8*1";

		var expected = new G12_ItemDetailAdjustment()
		{
			AdjustmentReasonCode = "uG",
			CreditDebitFlagCode = "1",
			CreditDebitQuantity = 4,
			UnitOrBasisForMeasurementCode = "F7",
			UnitPriceDifference = 5,
			UPCCaseCode = "p3MSN1PzUxU8",
			ProductServiceIDQualifier = "gh",
			ProductServiceID = "L",
			ProductServiceIDQualifier2 = "Z6",
			ProductServiceID2 = "u",
			PriceBracketIdentifier = "e",
			AmountOfAdjustment = "LD",
			ItemListCostNew = 8,
			ItemListCostOld = 1,
		};

		var actual = Map.MapObject<G12_ItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uG", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.CreditDebitFlagCode = "1";
		subject.AdjustmentReasonCode = adjustmentReasonCode;
			subject.UnitPriceDifference = 5;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
			subject.UnitPriceDifference = 5;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "F7", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "F7", false)]
	public void Validation_AllAreRequiredCreditDebitQuantity(decimal creditDebitQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = "1";
		if (creditDebitQuantity > 0)
			subject.CreditDebitQuantity = creditDebitQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UnitPriceDifference = 5;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(5, "LD", true)]
	[InlineData(5, "", true)]
	[InlineData(0, "LD", true)]
	public void Validation_AtLeastOneUnitPriceDifference(decimal unitPriceDifference, string amountOfAdjustment, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = "1";
		if (unitPriceDifference > 0)
			subject.UnitPriceDifference = unitPriceDifference;
		subject.AmountOfAdjustment = amountOfAdjustment;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("p3MSN1PzUxU8", "gh", true)]
	[InlineData("p3MSN1PzUxU8", "", true)]
	[InlineData("", "gh", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = "1";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.UnitPriceDifference = 5;
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gh", "L", true)]
	[InlineData("gh", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = "1";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UnitPriceDifference = 5;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Z6";
			subject.ProductServiceID2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z6", "u", true)]
	[InlineData("Z6", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "uG";
		subject.CreditDebitFlagCode = "1";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UnitPriceDifference = 5;
			subject.UPCCaseCode = "p3MSN1PzUxU8";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOrBasisForMeasurementCode = "F7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gh";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
