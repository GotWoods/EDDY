using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRF*g*X*G*HykMGa*D*9*Ma";

		var expected = new PRF_PurchaseOrderReference()
		{
			PurchaseOrderNumber = "g",
			ReleaseNumber = "X",
			ChangeOrderSequenceNumber = "G",
			PurchaseOrderDate = "HykMGa",
			AssignedIdentification = "D",
			ContractNumber = "9",
			PurchaseOrderTypeCode = "Ma",
		};

		var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new PRF_PurchaseOrderReference();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
