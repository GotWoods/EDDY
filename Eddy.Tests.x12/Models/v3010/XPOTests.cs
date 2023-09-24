using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XPOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XPO*6*Q*i*ZS";

		var expected = new XPO_PreassignedPurchaseOrderNumbers()
		{
			PurchaseOrderNumber = "6",
			PurchaseOrderNumber2 = "Q",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "ZS",
		};

		var actual = Map.MapObject<XPO_PreassignedPurchaseOrderNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new XPO_PreassignedPurchaseOrderNumbers();
		//Required fields
		//Test Parameters
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
