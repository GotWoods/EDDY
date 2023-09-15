using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*8*N*u*cY*S*pISfq2*f*Yg*rOyb90*8UA*Pa*jlHcCe*dh";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "8",
			InvoiceNumber = "N",
			ShipmentIdentificationNumber = "u",
			ShipmentMethodOfPayment = "cY",
			WeightUnitCode = "S",
			Date = "pISfq2",
			NetAmountDue = "f",
			CorrectionIndicator = "Yg",
			DeliveryDate = "rOyb90",
			DateTimeQualifier = "8UA",
			StandardCarrierAlphaCode = "Pa",
			Date2 = "jlHcCe",
			TariffServiceCode = "dh",
		};

		var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "cY";
		subject.Date = "pISfq2";
		subject.NetAmountDue = "f";
		subject.StandardCarrierAlphaCode = "Pa";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "rOyb90";
			subject.DateTimeQualifier = "8UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cY", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "N";
		subject.Date = "pISfq2";
		subject.NetAmountDue = "f";
		subject.StandardCarrierAlphaCode = "Pa";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "rOyb90";
			subject.DateTimeQualifier = "8UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pISfq2", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "N";
		subject.ShipmentMethodOfPayment = "cY";
		subject.NetAmountDue = "f";
		subject.StandardCarrierAlphaCode = "Pa";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "rOyb90";
			subject.DateTimeQualifier = "8UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "N";
		subject.ShipmentMethodOfPayment = "cY";
		subject.Date = "pISfq2";
		subject.StandardCarrierAlphaCode = "Pa";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "rOyb90";
			subject.DateTimeQualifier = "8UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rOyb90", "8UA", true)]
	[InlineData("rOyb90", "", false)]
	[InlineData("", "8UA", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "N";
		subject.ShipmentMethodOfPayment = "cY";
		subject.Date = "pISfq2";
		subject.NetAmountDue = "f";
		subject.StandardCarrierAlphaCode = "Pa";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pa", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "N";
		subject.ShipmentMethodOfPayment = "cY";
		subject.Date = "pISfq2";
		subject.NetAmountDue = "f";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "rOyb90";
			subject.DateTimeQualifier = "8UA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
