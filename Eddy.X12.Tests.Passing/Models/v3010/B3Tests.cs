using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*hTD*9*i*D6*3*UZvqd9*5*rI*lP1xTU*XJA*8J*WECsky";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			TransactionSetIdentifierCode = "hTD",
			InvoiceNumber = "9",
			ShipmentIdentificationNumber = "i",
			ShipmentMethodOfPayment = "D6",
			WeightUnitQualifier = "3",
			BillingDate = "UZvqd9",
			NetAmountDue = "5",
			CorrectionIndicator = "rI",
			DeliveryDate = "lP1xTU",
			DateTimeQualifier = "XJA",
			StandardCarrierAlphaCode = "8J",
			Date = "WECsky",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "D6";
		subject.BillingDate = "UZvqd9";
		subject.NetAmountDue = "5";
		subject.StandardCarrierAlphaCode = "8J";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D6", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.BillingDate = "UZvqd9";
		subject.NetAmountDue = "5";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UZvqd9", true)]
	public void Validation_RequiredBillingDate(string billingDate, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPayment = "D6";
		subject.NetAmountDue = "5";
		subject.StandardCarrierAlphaCode = "8J";
		subject.BillingDate = billingDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPayment = "D6";
		subject.BillingDate = "UZvqd9";
		subject.StandardCarrierAlphaCode = "8J";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8J", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPayment = "D6";
		subject.BillingDate = "UZvqd9";
		subject.NetAmountDue = "5";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
