using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*TC*hw*j*WN*cZfWM4ED*XFyH7F6l*8*eT*7";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "TC",
			ReferenceIdentificationQualifier = "hw",
			ReferenceIdentification = "j",
			ShipmentMethodOfPayment = "WN",
			Date = "cZfWM4ED",
			Date2 = "XFyH7F6l",
			Charge = "8",
			StandardCarrierAlphaCode = "eT",
			ReferenceIdentification2 = "7",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TC", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date = "cZfWM4ED";
		subject.Date2 = "XFyH7F6l";
		subject.Charge = "8";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hw", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date = "cZfWM4ED";
		subject.Date2 = "XFyH7F6l";
		subject.Charge = "8";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date = "cZfWM4ED";
		subject.Date2 = "XFyH7F6l";
		subject.Charge = "8";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WN", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ReferenceIdentification = "j";
		subject.Date = "cZfWM4ED";
		subject.Date2 = "XFyH7F6l";
		subject.Charge = "8";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cZfWM4ED", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date2 = "XFyH7F6l";
		subject.Charge = "8";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XFyH7F6l", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date = "cZfWM4ED";
		subject.Charge = "8";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "TC";
		subject.ReferenceIdentificationQualifier = "hw";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "WN";
		subject.Date = "cZfWM4ED";
		subject.Date2 = "XFyH7F6l";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
