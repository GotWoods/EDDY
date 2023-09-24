using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*s*yM*AC360smL*Z*bQJtSaM9*lM*1*7*h*Hw*Fw8";

		var expected = new B3B_BeginningSegmentForCarriersInvoice()
		{
			InvoiceNumber = "s",
			ShipmentMethodOfPayment = "yM",
			Date = "AC360smL",
			NetAmountDue = "Z",
			Date2 = "bQJtSaM9",
			StandardCarrierAlphaCode = "lM",
			TransportationMethodTypeCode = "1",
			ShipmentIdentificationNumber = "7",
			WeightUnitCode = "h",
			CorrectionIndicator = "Hw",
			CurrencyCode = "Fw8",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "yM";
		subject.Date = "AC360smL";
		subject.NetAmountDue = "Z";
		subject.StandardCarrierAlphaCode = "lM";
		subject.TransportationMethodTypeCode = "1";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yM", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "s";
		subject.Date = "AC360smL";
		subject.NetAmountDue = "Z";
		subject.StandardCarrierAlphaCode = "lM";
		subject.TransportationMethodTypeCode = "1";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AC360smL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "s";
		subject.ShipmentMethodOfPayment = "yM";
		subject.NetAmountDue = "Z";
		subject.StandardCarrierAlphaCode = "lM";
		subject.TransportationMethodTypeCode = "1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "s";
		subject.ShipmentMethodOfPayment = "yM";
		subject.Date = "AC360smL";
		subject.StandardCarrierAlphaCode = "lM";
		subject.TransportationMethodTypeCode = "1";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lM", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "s";
		subject.ShipmentMethodOfPayment = "yM";
		subject.Date = "AC360smL";
		subject.NetAmountDue = "Z";
		subject.TransportationMethodTypeCode = "1";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "s";
		subject.ShipmentMethodOfPayment = "yM";
		subject.Date = "AC360smL";
		subject.NetAmountDue = "Z";
		subject.StandardCarrierAlphaCode = "lM";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
