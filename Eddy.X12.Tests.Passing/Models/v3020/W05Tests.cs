using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W05*o*S*I*849878*z";

		var expected = new W05_ShippingOrderIdentification()
		{
			OrderStatusCode = "o",
			DepositorOrderNumber = "S",
			PurchaseOrderNumber = "I",
			LinkSequenceNumber = 849878,
			MasterReferenceLinkNumber = "z",
		};

		var actual = Map.MapObject<W05_ShippingOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.DepositorOrderNumber = "S";
		//Test Parameters
		subject.OrderStatusCode = orderStatusCode;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 849878;
			subject.MasterReferenceLinkNumber = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "o";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		//If one filled, all required
		if(subject.LinkSequenceNumber > 0 || subject.LinkSequenceNumber > 0 || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber))
		{
			subject.LinkSequenceNumber = 849878;
			subject.MasterReferenceLinkNumber = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(849878, "z", true)]
	[InlineData(849878, "", false)]
	[InlineData(0, "z", false)]
	public void Validation_AllAreRequiredLinkSequenceNumber(int linkSequenceNumber, string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new W05_ShippingOrderIdentification();
		//Required fields
		subject.OrderStatusCode = "o";
		subject.DepositorOrderNumber = "S";
		//Test Parameters
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
