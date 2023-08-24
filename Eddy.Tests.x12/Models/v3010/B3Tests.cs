using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*fv0*8*h*Xx*Q*bJHZUF*y*J2*XvfeRq*JO5*k9*Pwv6k6";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			TransactionSetIdentifierCode = "fv0",
			InvoiceNumber = "8",
			ShipmentIdentificationNumber = "h",
			ShipmentMethodOfPayment = "Xx",
			WeightUnitQualifier = "Q",
			BillingDate = "bJHZUF",
			NetAmountDue = "y",
			CorrectionIndicator = "J2",
			DeliveryDate = "XvfeRq",
			DateTimeQualifier = "JO5",
			StandardCarrierAlphaCode = "k9",
			Date = "Pwv6k6",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "Xx";
		subject.BillingDate = "bJHZUF";
		subject.NetAmountDue = "y";
		subject.StandardCarrierAlphaCode = "k9";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xx", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.BillingDate = "bJHZUF";
		subject.NetAmountDue = "y";
		subject.StandardCarrierAlphaCode = "k9";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bJHZUF", true)]
	public void Validation_RequiredBillingDate(string billingDate, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "Xx";
		subject.NetAmountDue = "y";
		subject.StandardCarrierAlphaCode = "k9";
		subject.BillingDate = billingDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "Xx";
		subject.BillingDate = "bJHZUF";
		subject.StandardCarrierAlphaCode = "k9";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "Xx";
		subject.BillingDate = "bJHZUF";
		subject.NetAmountDue = "y";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
