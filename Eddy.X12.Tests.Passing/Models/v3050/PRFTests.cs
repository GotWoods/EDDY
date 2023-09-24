using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRF*G*t*4*oZZafr*x*0*3H";

		var expected = new PRF_PurchaseOrderReference()
		{
			PurchaseOrderNumber = "G",
			ReleaseNumber = "t",
			ChangeOrderSequenceNumber = "4",
			Date = "oZZafr",
			AssignedIdentification = "x",
			ContractNumber = "0",
			PurchaseOrderTypeCode = "3H",
		};

		var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new PRF_PurchaseOrderReference();
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
