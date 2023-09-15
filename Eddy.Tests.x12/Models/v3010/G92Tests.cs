using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G92Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G92*HB*6OVdtI*B";

		var expected = new G92_PurchaseOrderChangeType()
		{
			ChangeOrResponseTypeCode = "HB",
			PurchaseOrderDate = "6OVdtI",
			PurchaseOrderNumber = "B",
		};

		var actual = Map.MapObject<G92_PurchaseOrderChangeType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HB", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.PurchaseOrderDate = "6OVdtI";
		subject.PurchaseOrderNumber = "B";
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6OVdtI", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "HB";
		subject.PurchaseOrderNumber = "B";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "HB";
		subject.PurchaseOrderDate = "6OVdtI";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
