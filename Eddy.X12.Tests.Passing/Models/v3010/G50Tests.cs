using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G50Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G50*G*JhLfkH*J*X*b*211878*o8";

		var expected = new G50_PurchaseOrderIdentification()
		{
			OrderStatusCode = "G",
			PurchaseOrderDate = "JhLfkH",
			PurchaseOrderNumber = "J",
			TaxExemptCode = "X",
			MasterReferenceLinkNumber = "b",
			LinkSequenceNumber = 211878,
			PurchaseOrderTypeCode = "o8",
		};

		var actual = Map.MapObject<G50_PurchaseOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.PurchaseOrderDate = "JhLfkH";
		subject.PurchaseOrderNumber = "J";
		subject.OrderStatusCode = orderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JhLfkH", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "G";
		subject.PurchaseOrderNumber = "J";
		subject.PurchaseOrderDate = purchaseOrderDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "G";
		subject.PurchaseOrderDate = "JhLfkH";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
