using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*Y*b*7c*7";

		var expected = new B10_BeginningSegmentForShipmentStatusMessage()
		{
			InvoiceNumber = "Y",
			ShipmentIdentificationNumber = "b",
			StandardCarrierAlphaCode = "7c",
			InquiryRequestNumber = 7,
		};

		var actual = Map.MapObject<B10_BeginningSegmentForShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.ShipmentIdentificationNumber = "b";
		subject.StandardCarrierAlphaCode = "7c";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.InvoiceNumber = "Y";
		subject.StandardCarrierAlphaCode = "7c";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7c", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.InvoiceNumber = "Y";
		subject.ShipmentIdentificationNumber = "b";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
