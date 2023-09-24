using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRF*S*r*5*QBfovm*c*l";

		var expected = new PRF_PurchaseOrderReference()
		{
			PurchaseOrderNumber = "S",
			ReleaseNumber = "r",
			ChangeOrderSequenceNumber = "5",
			PurchaseOrderDate = "QBfovm",
			AssignedIdentification = "c",
			ContractNumber = "l",
		};

		var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new PRF_PurchaseOrderReference();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
