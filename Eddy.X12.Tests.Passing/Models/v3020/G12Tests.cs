using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G12*lV*L*4*2O*1*6vrf50vj6Bei*fA*6*wn*W*c*am*7*8";

		var expected = new G12_ItemDetailAdjustment()
		{
			AdjustmentReasonCode = "lV",
			CreditDebitFlagCode = "L",
			CreditDebitQuantity = 4,
			UnitOfMeasurementCode = "2O",
			UnitPriceDifference = 1,
			UPCCaseCode = "6vrf50vj6Bei",
			ProductServiceIDQualifier = "fA",
			ProductServiceID = "6",
			ProductServiceIDQualifier2 = "wn",
			ProductServiceID2 = "W",
			PriceBracketIdentifier = "c",
			AmountOfAdjustment = "am",
			ItemListCostNew = 7,
			ItemListCostOld = 8,
		};

		var actual = Map.MapObject<G12_ItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lV", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.CreditDebitFlagCode = "L";
		subject.AdjustmentReasonCode = adjustmentReasonCode;
			subject.UnitPriceDifference = 1;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
			subject.UnitPriceDifference = 1;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "2O", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "2O", false)]
	public void Validation_AllAreRequiredCreditDebitQuantity(decimal creditDebitQuantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = "L";
		if (creditDebitQuantity > 0)
			subject.CreditDebitQuantity = creditDebitQuantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UnitPriceDifference = 1;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(1, "am", true)]
	[InlineData(1, "", true)]
	[InlineData(0, "am", true)]
	public void Validation_AtLeastOneUnitPriceDifference(decimal unitPriceDifference, string amountOfAdjustment, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = "L";
		if (unitPriceDifference > 0)
			subject.UnitPriceDifference = unitPriceDifference;
		subject.AmountOfAdjustment = amountOfAdjustment;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6vrf50vj6Bei", "fA", true)]
	[InlineData("6vrf50vj6Bei", "", true)]
	[InlineData("", "fA", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = "L";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.UnitPriceDifference = 1;
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fA", "6", true)]
	[InlineData("fA", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = "L";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UnitPriceDifference = 1;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "wn";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wn", "W", true)]
	[InlineData("wn", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "lV";
		subject.CreditDebitFlagCode = "L";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UnitPriceDifference = 1;
			subject.UPCCaseCode = "6vrf50vj6Bei";
		//If one is filled, all are required
		if(subject.CreditDebitQuantity > 0 || subject.CreditDebitQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.CreditDebitQuantity = 4;
			subject.UnitOfMeasurementCode = "2O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fA";
			subject.ProductServiceID = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
