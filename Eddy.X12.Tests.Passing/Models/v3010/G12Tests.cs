using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G12*XA*f*7*v5*9*dSO3LdU7bbPB*6q*L*6M*8*j*3Y*5*6";

		var expected = new G12_ItemDetailAdjustment()
		{
			AdjustmentReasonCode = "XA",
			CreditDebitFlagCode = "f",
			CreditDebitQuantity = 7,
			UnitOfMeasurementCode = "v5",
			UnitPriceDifference = 9,
			UPCCaseCode = "dSO3LdU7bbPB",
			ProductServiceIDQualifier = "6q",
			ProductServiceID = "L",
			ProductServiceIDQualifier2 = "6M",
			ProductServiceID2 = "8",
			PriceBracketIdentifier = "j",
			AmountOfAdjustment = "3Y",
			ItemListCostNew = 5,
			ItemListCostOld = 6,
		};

		var actual = Map.MapObject<G12_ItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XA", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.CreditDebitFlagCode = "f";
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G12_ItemDetailAdjustment();
		subject.AdjustmentReasonCode = "XA";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
