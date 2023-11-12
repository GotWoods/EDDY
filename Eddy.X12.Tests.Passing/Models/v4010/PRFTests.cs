using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRF*2*6*Y*668Y2FA8*Q*m*EQ";

		var expected = new PRF_PurchaseOrderReference()
		{
			PurchaseOrderNumber = "2",
			ReleaseNumber = "6",
			ChangeOrderSequenceNumber = "Y",
			Date = "668Y2FA8",
			AssignedIdentification = "Q",
			ContractNumber = "m",
			PurchaseOrderTypeCode = "EQ",
		};

		var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new PRF_PurchaseOrderReference();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
