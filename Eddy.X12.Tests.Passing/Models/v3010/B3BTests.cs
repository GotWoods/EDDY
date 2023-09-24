using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B3BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3B*Q*0e*TbLTgj*z*Ii29Ev*OJ*7*G*k*Vd";

		var expected = new B3B_BeginningSegmentForCarriersInvoice()
		{
			InvoiceNumber = "Q",
			ShipmentMethodOfPayment = "0e",
			Date = "TbLTgj",
			NetAmountDue = "z",
			Date2 = "Ii29Ev",
			StandardCarrierAlphaCode = "OJ",
			TransportationMethodTypeCode = "7",
			ShipmentIdentificationNumber = "G",
			WeightUnitQualifier = "k",
			CorrectionIndicator = "Vd",
		};

		var actual = Map.MapObject<B3B_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.ShipmentMethodOfPayment = "0e";
		subject.Date = "TbLTgj";
		subject.NetAmountDue = "z";
		subject.Date2 = "Ii29Ev";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = "7";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0e", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.Date = "TbLTgj";
		subject.NetAmountDue = "z";
		subject.Date2 = "Ii29Ev";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = "7";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TbLTgj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.ShipmentMethodOfPayment = "0e";
		subject.NetAmountDue = "z";
		subject.Date2 = "Ii29Ev";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = "7";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.ShipmentMethodOfPayment = "0e";
		subject.Date = "TbLTgj";
		subject.Date2 = "Ii29Ev";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = "7";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ii29Ev", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.ShipmentMethodOfPayment = "0e";
		subject.Date = "TbLTgj";
		subject.NetAmountDue = "z";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = "7";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.ShipmentMethodOfPayment = "0e";
		subject.Date = "TbLTgj";
		subject.NetAmountDue = "z";
		subject.Date2 = "Ii29Ev";
		subject.TransportationMethodTypeCode = "7";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new B3B_BeginningSegmentForCarriersInvoice();
		subject.InvoiceNumber = "Q";
		subject.ShipmentMethodOfPayment = "0e";
		subject.Date = "TbLTgj";
		subject.NetAmountDue = "z";
		subject.Date2 = "Ii29Ev";
		subject.StandardCarrierAlphaCode = "OJ";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
