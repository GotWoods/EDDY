using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*7*jD*zuLf3NIJ*a*e6QaeqI3*dK*W*R*f*y7*t4q";

		var expected = new B3B_BeginningSegmentForRailCarriersInvoice()
		{
			InvoiceNumber = "7",
			ShipmentMethodOfPayment = "jD",
			Date = "zuLf3NIJ",
			NetAmountDue = "a",
			Date2 = "e6QaeqI3",
			StandardCarrierAlphaCode = "dK",
			TransportationMethodTypeCode = "W",
			ShipmentIdentificationNumber = "R",
			WeightUnitCode = "f",
			CorrectionIndicator = "y7",
			CurrencyCode = "t4q",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForRailCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.ShipmentMethodOfPayment = "jD";
		subject.Date = "zuLf3NIJ";
		subject.NetAmountDue = "a";
		subject.StandardCarrierAlphaCode = "dK";
		subject.TransportationMethodTypeCode = "W";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jD", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "7";
		subject.Date = "zuLf3NIJ";
		subject.NetAmountDue = "a";
		subject.StandardCarrierAlphaCode = "dK";
		subject.TransportationMethodTypeCode = "W";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zuLf3NIJ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "7";
		subject.ShipmentMethodOfPayment = "jD";
		subject.NetAmountDue = "a";
		subject.StandardCarrierAlphaCode = "dK";
		subject.TransportationMethodTypeCode = "W";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "7";
		subject.ShipmentMethodOfPayment = "jD";
		subject.Date = "zuLf3NIJ";
		subject.StandardCarrierAlphaCode = "dK";
		subject.TransportationMethodTypeCode = "W";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dK", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "7";
		subject.ShipmentMethodOfPayment = "jD";
		subject.Date = "zuLf3NIJ";
		subject.NetAmountDue = "a";
		subject.TransportationMethodTypeCode = "W";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "7";
		subject.ShipmentMethodOfPayment = "jD";
		subject.Date = "zuLf3NIJ";
		subject.NetAmountDue = "a";
		subject.StandardCarrierAlphaCode = "dK";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
