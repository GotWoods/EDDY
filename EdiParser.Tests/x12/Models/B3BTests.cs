using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*a*rL*I6gOXjcL*D*u3lYtBRm*Qe*O*O*p*6M*o4M";

		var expected = new B3B_BeginningSegmentForRailCarriersInvoice()
		{
			InvoiceNumber = "a",
			ShipmentMethodOfPaymentCode = "rL",
			Date = "I6gOXjcL",
			NetAmountDue = "D",
			Date2 = "u3lYtBRm",
			StandardCarrierAlphaCode = "Qe",
			TransportationMethodTypeCode = "O",
			ShipmentIdentificationNumber = "O",
			WeightUnitCode = "p",
			CorrectionIndicatorCode = "6M",
			CurrencyCode = "o4M",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForRailCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validatation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.ShipmentMethodOfPaymentCode = "rL";
		subject.Date = "I6gOXjcL";
		subject.NetAmountDue = "D";
		subject.StandardCarrierAlphaCode = "Qe";
		subject.TransportationMethodTypeCode = "O";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rL", true)]
	public void Validatation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.Date = "I6gOXjcL";
		subject.NetAmountDue = "D";
		subject.StandardCarrierAlphaCode = "Qe";
		subject.TransportationMethodTypeCode = "O";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I6gOXjcL", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPaymentCode = "rL";
		subject.NetAmountDue = "D";
		subject.StandardCarrierAlphaCode = "Qe";
		subject.TransportationMethodTypeCode = "O";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validatation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPaymentCode = "rL";
		subject.Date = "I6gOXjcL";
		subject.StandardCarrierAlphaCode = "Qe";
		subject.TransportationMethodTypeCode = "O";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qe", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPaymentCode = "rL";
		subject.Date = "I6gOXjcL";
		subject.NetAmountDue = "D";
		subject.TransportationMethodTypeCode = "O";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validatation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPaymentCode = "rL";
		subject.Date = "I6gOXjcL";
		subject.NetAmountDue = "D";
		subject.StandardCarrierAlphaCode = "Qe";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
