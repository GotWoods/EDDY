using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRF*J*5*3*g8afAs*1*g*B3";

		var expected = new PRF_PurchaseOrderReference()
		{
			PurchaseOrderNumber = "J",
			ReleaseNumber = "5",
			ChangeOrderSequenceNumber = "3",
			Date = "g8afAs",
			AssignedIdentification = "1",
			ContractNumber = "g",
			PurchaseOrderTypeCode = "B3",
		};

		var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new PRF_PurchaseOrderReference();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
