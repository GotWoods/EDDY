using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class W05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W05*F*s*U*537689*S*RW*c*YX";

		var expected = new W05_ShippingOrderIdentification()
		{
			OrderStatusCode = "F",
			DepositorOrderNumber = "s",
			PurchaseOrderNumber = "U",
			LinkSequenceNumber = 537689,
			MasterReferenceLinkNumber = "S",
			TransactionTypeCode = "RW",
			ActionCode = "c",
			PurchaseOrderTypeCode = "YX",
		};

		var actual = Map.MapObject<W05_ShippingOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.DepositorOrderNumber = "s";
		//Test Parameters
		subject.OrderStatusCode = orderStatusCode;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 537689;
			subject.MasterReferenceLinkNumber = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "F";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 537689;
			subject.MasterReferenceLinkNumber = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(537689, "S", true)]
	[InlineData(537689, "", false)]
	[InlineData(0, "S", false)]
	public void Validation_AllAreRequiredLinkSequenceNumber(int linkSequenceNumber, string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "F";
		subject.DepositorOrderNumber = "s";
		//Test Parameters
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
