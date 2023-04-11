using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G50Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G50*f*0NkaoWDh*z*j*K*715917*BR";

		var expected = new G50_PurchaseOrderIdentification()
		{
			OrderStatusCode = "f",
			Date = "0NkaoWDh",
			PurchaseOrderNumber = "z",
			TaxExemptCode = "j",
			MasterReferenceLinkNumber = "K",
			LinkSequenceNumber = 715917,
			PurchaseOrderTypeCode = "BR",
		};

		var actual = Map.MapObject<G50_PurchaseOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.Date = "0NkaoWDh";
		subject.PurchaseOrderNumber = "z";
		subject.OrderStatusCode = orderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0NkaoWDh", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "f";
		subject.PurchaseOrderNumber = "z";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "f";
		subject.Date = "0NkaoWDh";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("K", 715917, true)]
	[InlineData("", 715917, false)]
	[InlineData("K", 0, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "f";
		subject.Date = "0NkaoWDh";
		subject.PurchaseOrderNumber = "z";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
		subject.LinkSequenceNumber = linkSequenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
