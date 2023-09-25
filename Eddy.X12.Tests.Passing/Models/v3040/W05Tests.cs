using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W05*c*5*t*485526*c*iL*r";

		var expected = new W05_ShippingOrderIdentification()
		{
			OrderStatusCode = "c",
			DepositorOrderNumber = "5",
			PurchaseOrderNumber = "t",
			LinkSequenceNumber = 485526,
			MasterReferenceLinkNumber = "c",
			TransactionTypeCode = "iL",
			ActionCode = "r",
		};

		var actual = Map.MapObject<W05_ShippingOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.DepositorOrderNumber = "5";
		//Test Parameters
		subject.OrderStatusCode = orderStatusCode;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 485526;
			subject.MasterReferenceLinkNumber = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "c";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 485526;
			subject.MasterReferenceLinkNumber = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(485526, "c", true)]
	[InlineData(485526, "", false)]
	[InlineData(0, "c", false)]
	public void Validation_AllAreRequiredLinkSequenceNumber(int linkSequenceNumber, string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "c";
		subject.DepositorOrderNumber = "5";
		//Test Parameters
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
