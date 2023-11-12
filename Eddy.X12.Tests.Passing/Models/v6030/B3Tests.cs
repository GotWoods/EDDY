using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*o*9*f*6K*u*0UYRDgix*8*RO*qc2qX4FM*1QP*73*8tmgZYyw*tv*pfJ";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "o",
			InvoiceNumber = "9",
			ShipmentIdentificationNumber = "f",
			ShipmentMethodOfPaymentCode = "6K",
			WeightUnitCode = "u",
			Date = "0UYRDgix",
			NetAmountDue = "8",
			CorrectionIndicatorCode = "RO",
			DeliveryDate = "qc2qX4FM",
			DateTimeQualifier = "1QP",
			StandardCarrierAlphaCode = "73",
			Date2 = "8tmgZYyw",
			TariffServiceCode = "tv",
			TransportationTermsCode = "pfJ",
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
		subject.ShipmentMethodOfPaymentCode = "6K";
		subject.Date = "0UYRDgix";
		subject.NetAmountDue = "8";
		subject.StandardCarrierAlphaCode = "73";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "qc2qX4FM";
			subject.DateTimeQualifier = "1QP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6K", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.Date = "0UYRDgix";
		subject.NetAmountDue = "8";
		subject.StandardCarrierAlphaCode = "73";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "qc2qX4FM";
			subject.DateTimeQualifier = "1QP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0UYRDgix", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPaymentCode = "6K";
		subject.NetAmountDue = "8";
		subject.StandardCarrierAlphaCode = "73";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "qc2qX4FM";
			subject.DateTimeQualifier = "1QP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPaymentCode = "6K";
		subject.Date = "0UYRDgix";
		subject.StandardCarrierAlphaCode = "73";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "qc2qX4FM";
			subject.DateTimeQualifier = "1QP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qc2qX4FM", "1QP", true)]
	[InlineData("qc2qX4FM", "", false)]
	[InlineData("", "1QP", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPaymentCode = "6K";
		subject.Date = "0UYRDgix";
		subject.NetAmountDue = "8";
		subject.StandardCarrierAlphaCode = "73";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("73", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "9";
		subject.ShipmentMethodOfPaymentCode = "6K";
		subject.Date = "0UYRDgix";
		subject.NetAmountDue = "8";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "qc2qX4FM";
			subject.DateTimeQualifier = "1QP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
