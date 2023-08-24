using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*a*LW*5NBvsR*0*NUPx8j*mv*U*1*6*Cn";

		var expected = new B3B_BeginningSegmentForCarriersInvoice()
		{
			InvoiceNumber = "a",
			ShipmentMethodOfPayment = "LW",
			Date = "5NBvsR",
			NetAmountDue = "0",
			Date2 = "NUPx8j",
			StandardCarrierAlphaCode = "mv",
			TransportationMethodTypeCode = "U",
			ShipmentIdentificationNumber = "1",
			WeightUnitQualifier = "6",
			CorrectionIndicator = "Cn",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "LW";
		subject.Date = "5NBvsR";
		subject.NetAmountDue = "0";
		subject.Date2 = "NUPx8j";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = "U";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LW", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.Date = "5NBvsR";
		subject.NetAmountDue = "0";
		subject.Date2 = "NUPx8j";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = "U";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5NBvsR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPayment = "LW";
		subject.NetAmountDue = "0";
		subject.Date2 = "NUPx8j";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = "U";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPayment = "LW";
		subject.Date = "5NBvsR";
		subject.Date2 = "NUPx8j";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = "U";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NUPx8j", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPayment = "LW";
		subject.Date = "5NBvsR";
		subject.NetAmountDue = "0";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = "U";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mv", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPayment = "LW";
		subject.Date = "5NBvsR";
		subject.NetAmountDue = "0";
		subject.Date2 = "NUPx8j";
		subject.TransportationMethodTypeCode = "U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "a";
		subject.ShipmentMethodOfPayment = "LW";
		subject.Date = "5NBvsR";
		subject.NetAmountDue = "0";
		subject.Date2 = "NUPx8j";
		subject.StandardCarrierAlphaCode = "mv";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
