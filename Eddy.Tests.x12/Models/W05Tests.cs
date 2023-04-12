using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W05*0*n*H*118733*8*dD*A*uv";

		var expected = new W05_ShippingOrderIdentification()
		{
			OrderStatusCode = "0",
			DepositorOrderNumber = "n",
			PurchaseOrderNumber = "H",
			LinkSequenceNumber = 118733,
			MasterReferenceLinkNumber = "8",
			TransactionTypeCode = "dD",
			ActionCode = "A",
			PurchaseOrderTypeCode = "uv",
		};

		var actual = Map.MapObject<W05_ShippingOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		subject.DepositorOrderNumber = "n";
		subject.OrderStatusCode = orderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		subject.OrderStatusCode = "0";
		subject.DepositorOrderNumber = depositorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(118733, "8", true)]
	[InlineData(0, "8", false)]
	[InlineData(118733, "", false)]
	public void Validation_AllAreRequiredLinkSequenceNumber(int linkSequenceNumber, string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		subject.OrderStatusCode = "0";
		subject.DepositorOrderNumber = "n";
		if (linkSequenceNumber > 0)
		subject.LinkSequenceNumber = linkSequenceNumber;
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
