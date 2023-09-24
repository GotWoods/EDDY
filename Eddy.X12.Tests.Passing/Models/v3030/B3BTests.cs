using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*d*qq*eNtUIY*S*WQiJIz*gP*I*l*j*V1";

		var expected = new B3B_BeginningSegmentForCarriersInvoice()
		{
			InvoiceNumber = "d",
			ShipmentMethodOfPayment = "qq",
			Date = "eNtUIY",
			NetAmountDue = "S",
			Date2 = "WQiJIz",
			StandardCarrierAlphaCode = "gP",
			TransportationMethodTypeCode = "I",
			ShipmentIdentificationNumber = "l",
			WeightUnitCode = "j",
			CorrectionIndicator = "V1",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "qq";
		subject.Date = "eNtUIY";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "gP";
		subject.TransportationMethodTypeCode = "I";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qq", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "d";
		subject.Date = "eNtUIY";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "gP";
		subject.TransportationMethodTypeCode = "I";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eNtUIY", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "d";
		subject.ShipmentMethodOfPayment = "qq";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "gP";
		subject.TransportationMethodTypeCode = "I";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "d";
		subject.ShipmentMethodOfPayment = "qq";
		subject.Date = "eNtUIY";
		subject.StandardCarrierAlphaCode = "gP";
		subject.TransportationMethodTypeCode = "I";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gP", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "d";
		subject.ShipmentMethodOfPayment = "qq";
		subject.Date = "eNtUIY";
		subject.NetAmountDue = "S";
		subject.TransportationMethodTypeCode = "I";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "d";
		subject.ShipmentMethodOfPayment = "qq";
		subject.Date = "eNtUIY";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "gP";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
