using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*2*sr*tDn9nBBo*C*3p4AlLCw*Ki*T*t*8*Bd*OEc";

		var expected = new B3B_BeginningSegmentForRailCarriersInvoice()
		{
			InvoiceNumber = "2",
			ShipmentMethodOfPaymentCode = "sr",
			Date = "tDn9nBBo",
			NetAmountDue = "C",
			Date2 = "3p4AlLCw",
			StandardCarrierAlphaCode = "Ki",
			TransportationMethodTypeCode = "T",
			ShipmentIdentificationNumber = "t",
			WeightUnitCode = "8",
			CorrectionIndicatorCode = "Bd",
			CurrencyCode = "OEc",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForRailCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.ShipmentMethodOfPaymentCode = "sr";
		subject.Date = "tDn9nBBo";
		subject.NetAmountDue = "C";
		subject.StandardCarrierAlphaCode = "Ki";
		subject.TransportationMethodTypeCode = "T";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sr", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "2";
		subject.Date = "tDn9nBBo";
		subject.NetAmountDue = "C";
		subject.StandardCarrierAlphaCode = "Ki";
		subject.TransportationMethodTypeCode = "T";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tDn9nBBo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "2";
		subject.ShipmentMethodOfPaymentCode = "sr";
		subject.NetAmountDue = "C";
		subject.StandardCarrierAlphaCode = "Ki";
		subject.TransportationMethodTypeCode = "T";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "2";
		subject.ShipmentMethodOfPaymentCode = "sr";
		subject.Date = "tDn9nBBo";
		subject.StandardCarrierAlphaCode = "Ki";
		subject.TransportationMethodTypeCode = "T";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ki", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "2";
		subject.ShipmentMethodOfPaymentCode = "sr";
		subject.Date = "tDn9nBBo";
		subject.NetAmountDue = "C";
		subject.TransportationMethodTypeCode = "T";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForRailCarriersInvoice();
		subject.InvoiceNumber = "2";
		subject.ShipmentMethodOfPaymentCode = "sr";
		subject.Date = "tDn9nBBo";
		subject.NetAmountDue = "C";
		subject.StandardCarrierAlphaCode = "Ki";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
