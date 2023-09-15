using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*G*cQ*RrJw4U*x*o3O03Q*eU*q*L*Z*1P*H0r";

		var expected = new B3B_BeginningSegmentForCarriersInvoice()
		{
			InvoiceNumber = "G",
			ShipmentMethodOfPayment = "cQ",
			Date = "RrJw4U",
			NetAmountDue = "x",
			Date2 = "o3O03Q",
			StandardCarrierAlphaCode = "eU",
			TransportationMethodTypeCode = "q",
			ShipmentIdentificationNumber = "L",
			WeightUnitCode = "Z",
			CorrectionIndicator = "1P",
			CurrencyCode = "H0r",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "cQ";
		subject.Date = "RrJw4U";
		subject.NetAmountDue = "x";
		subject.StandardCarrierAlphaCode = "eU";
		subject.TransportationMethodTypeCode = "q";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cQ", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "G";
		subject.Date = "RrJw4U";
		subject.NetAmountDue = "x";
		subject.StandardCarrierAlphaCode = "eU";
		subject.TransportationMethodTypeCode = "q";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RrJw4U", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "G";
		subject.ShipmentMethodOfPayment = "cQ";
		subject.NetAmountDue = "x";
		subject.StandardCarrierAlphaCode = "eU";
		subject.TransportationMethodTypeCode = "q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "G";
		subject.ShipmentMethodOfPayment = "cQ";
		subject.Date = "RrJw4U";
		subject.StandardCarrierAlphaCode = "eU";
		subject.TransportationMethodTypeCode = "q";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eU", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "G";
		subject.ShipmentMethodOfPayment = "cQ";
		subject.Date = "RrJw4U";
		subject.NetAmountDue = "x";
		subject.TransportationMethodTypeCode = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "G";
		subject.ShipmentMethodOfPayment = "cQ";
		subject.Date = "RrJw4U";
		subject.NetAmountDue = "x";
		subject.StandardCarrierAlphaCode = "eU";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
