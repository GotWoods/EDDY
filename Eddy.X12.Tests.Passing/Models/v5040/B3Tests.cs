using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*N*x*3*kh*D*s5TXQc4v*1*Eo*NCrSUpp4*J1q*B4*MqAzt1uO*XE*Enb";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "N",
			InvoiceNumber = "x",
			ShipmentIdentificationNumber = "3",
			ShipmentMethodOfPayment = "kh",
			WeightUnitCode = "D",
			Date = "s5TXQc4v",
			NetAmountDue = "1",
			CorrectionIndicator = "Eo",
			DeliveryDate = "NCrSUpp4",
			DateTimeQualifier = "J1q",
			StandardCarrierAlphaCode = "B4",
			Date2 = "MqAzt1uO",
			TariffServiceCode = "XE",
			TransportationTermsCode = "Enb",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "kh";
		subject.Date = "s5TXQc4v";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "B4";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "NCrSUpp4";
			subject.DateTimeQualifier = "J1q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kh", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "x";
		subject.Date = "s5TXQc4v";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "B4";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "NCrSUpp4";
			subject.DateTimeQualifier = "J1q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s5TXQc4v", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "x";
		subject.ShipmentMethodOfPayment = "kh";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "B4";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "NCrSUpp4";
			subject.DateTimeQualifier = "J1q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "x";
		subject.ShipmentMethodOfPayment = "kh";
		subject.Date = "s5TXQc4v";
		subject.StandardCarrierAlphaCode = "B4";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "NCrSUpp4";
			subject.DateTimeQualifier = "J1q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NCrSUpp4", "J1q", true)]
	[InlineData("NCrSUpp4", "", false)]
	[InlineData("", "J1q", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "x";
		subject.ShipmentMethodOfPayment = "kh";
		subject.Date = "s5TXQc4v";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = "B4";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "x";
		subject.ShipmentMethodOfPayment = "kh";
		subject.Date = "s5TXQc4v";
		subject.NetAmountDue = "1";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "NCrSUpp4";
			subject.DateTimeQualifier = "J1q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
