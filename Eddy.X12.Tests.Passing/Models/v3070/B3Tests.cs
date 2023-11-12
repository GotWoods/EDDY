using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*6*S*q*1n*M*bYcFTT*1*Ek*pvA64d*3aI*KJ*2CLsHx*FH*b76";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "6",
			InvoiceNumber = "S",
			ShipmentIdentificationNumber = "q",
			ShipmentMethodOfPayment = "1n",
			WeightUnitCode = "M",
			Date = "bYcFTT",
			NetAmountDue = "1",
			CorrectionIndicator = "Ek",
			DeliveryDate = "pvA64d",
			DateTimeQualifier = "3aI",
			StandardCarrierAlphaCode = "KJ",
			Date2 = "2CLsHx",
			TariffServiceCode = "FH",
			TransportationTermsCode = "b76",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "1n";
		subject.Date = "bYcFTT";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "KJ";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "pvA64d";
			subject.DateTimeQualifier = "3aI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1n", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "S";
		subject.Date = "bYcFTT";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "KJ";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "pvA64d";
			subject.DateTimeQualifier = "3aI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bYcFTT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "S";
		subject.ShipmentMethodOfPayment = "1n";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "KJ";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "pvA64d";
			subject.DateTimeQualifier = "3aI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "S";
		subject.ShipmentMethodOfPayment = "1n";
		subject.Date = "bYcFTT";
		subject.StandardCarrierAlphaCode = "KJ";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "pvA64d";
			subject.DateTimeQualifier = "3aI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pvA64d", "3aI", true)]
	[InlineData("pvA64d", "", false)]
	[InlineData("", "3aI", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "S";
		subject.ShipmentMethodOfPayment = "1n";
		subject.Date = "bYcFTT";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "KJ";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "S";
		subject.ShipmentMethodOfPayment = "1n";
		subject.Date = "bYcFTT";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "pvA64d";
			subject.DateTimeQualifier = "3aI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
