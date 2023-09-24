using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*n*p*n*rU*3*BaTCNk*G*7V*epGO5n*Fla*8B*hDNuQW";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "n",
			InvoiceNumber = "p",
			ShipmentIdentificationNumber = "n",
			ShipmentMethodOfPayment = "rU",
			WeightUnitQualifier = "3",
			Date = "BaTCNk",
			NetAmountDue = "G",
			CorrectionIndicator = "7V",
			DeliveryDate = "epGO5n",
			DateTimeQualifier = "Fla",
			StandardCarrierAlphaCode = "8B",
			Date2 = "hDNuQW",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "rU";
		subject.Date = "BaTCNk";
		subject.NetAmountDue = "G";
		subject.StandardCarrierAlphaCode = "8B";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "epGO5n";
			subject.DateTimeQualifier = "Fla";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rU", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "p";
		subject.Date = "BaTCNk";
		subject.NetAmountDue = "G";
		subject.StandardCarrierAlphaCode = "8B";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "epGO5n";
			subject.DateTimeQualifier = "Fla";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BaTCNk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "p";
		subject.ShipmentMethodOfPayment = "rU";
		subject.NetAmountDue = "G";
		subject.StandardCarrierAlphaCode = "8B";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "epGO5n";
			subject.DateTimeQualifier = "Fla";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "p";
		subject.ShipmentMethodOfPayment = "rU";
		subject.Date = "BaTCNk";
		subject.StandardCarrierAlphaCode = "8B";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "epGO5n";
			subject.DateTimeQualifier = "Fla";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("epGO5n", "Fla", true)]
	[InlineData("epGO5n", "", false)]
	[InlineData("", "Fla", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "p";
		subject.ShipmentMethodOfPayment = "rU";
		subject.Date = "BaTCNk";
		subject.NetAmountDue = "G";
		subject.StandardCarrierAlphaCode = "8B";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8B", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "p";
		subject.ShipmentMethodOfPayment = "rU";
		subject.Date = "BaTCNk";
		subject.NetAmountDue = "G";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "epGO5n";
			subject.DateTimeQualifier = "Fla";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
