using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*i*2*xz*8";

		var expected = new B10_BeginningSegmentForShipmentStatusMessage()
		{
			InvoiceNumber = "i",
			ShipmentIdentificationNumber = "2",
			StandardCarrierAlphaCode = "xz",
			InquiryRequestNumber = 8,
		};

		var actual = Map.MapObject<B10_BeginningSegmentForShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.ShipmentIdentificationNumber = "2";
		subject.StandardCarrierAlphaCode = "xz";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.InvoiceNumber = "i";
		subject.StandardCarrierAlphaCode = "xz";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xz", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForShipmentStatusMessage();
		subject.InvoiceNumber = "i";
		subject.ShipmentIdentificationNumber = "2";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
