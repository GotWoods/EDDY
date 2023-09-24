using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class B3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3*P*8*m*eC*1*NktMbET0*S*Et*zcXfZy6y*FUk*eo*2RFAFBX8*gT*FW0";

		var expected = new B3_BeginningSegmentForCarriersInvoice()
		{
			ShipmentQualifier = "P",
			InvoiceNumber = "8",
			ShipmentIdentificationNumber = "m",
			ShipmentMethodOfPayment = "eC",
			WeightUnitCode = "1",
			Date = "NktMbET0",
			NetAmountDue = "S",
			CorrectionIndicator = "Et",
			DeliveryDate = "zcXfZy6y",
			DateTimeQualifier = "FUk",
			StandardCarrierAlphaCode = "eo",
			Date2 = "2RFAFBX8",
			TariffServiceCode = "gT",
			TransportationTermsCode = "FW0",
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
		subject.ShipmentMethodOfPayment = "eC";
		subject.Date = "NktMbET0";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "eo";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "zcXfZy6y";
			subject.DateTimeQualifier = "FUk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eC", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.Date = "NktMbET0";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "eo";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "zcXfZy6y";
			subject.DateTimeQualifier = "FUk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NktMbET0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "eC";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "eo";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "zcXfZy6y";
			subject.DateTimeQualifier = "FUk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "eC";
		subject.Date = "NktMbET0";
		subject.StandardCarrierAlphaCode = "eo";
		subject.NetAmountDue = netAmountDue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "zcXfZy6y";
			subject.DateTimeQualifier = "FUk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zcXfZy6y", "FUk", true)]
	[InlineData("zcXfZy6y", "", false)]
	[InlineData("", "FUk", false)]
	public void Validation_AllAreRequiredDeliveryDate(string deliveryDate, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "eC";
		subject.Date = "NktMbET0";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = "eo";
		subject.DeliveryDate = deliveryDate;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eo", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "8";
		subject.ShipmentMethodOfPayment = "eC";
		subject.Date = "NktMbET0";
		subject.NetAmountDue = "S";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DeliveryDate) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.DeliveryDate = "zcXfZy6y";
			subject.DateTimeQualifier = "FUk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
