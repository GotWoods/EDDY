using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*vQ*4V*j*U3*ihyu3ELL*m9fHgAUJ*M*Ej*0";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "vQ",
			ReferenceIdentificationQualifier = "4V",
			ReferenceIdentification = "j",
			ShipmentMethodOfPayment = "U3",
			Date = "ihyu3ELL",
			Date2 = "m9fHgAUJ",
			Charge = "M",
			StandardCarrierAlphaCode = "Ej",
			ReferenceIdentification2 = "0",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vQ", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date = "ihyu3ELL";
		subject.Date2 = "m9fHgAUJ";
		subject.Charge = "M";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4V", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date = "ihyu3ELL";
		subject.Date2 = "m9fHgAUJ";
		subject.Charge = "M";
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
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date = "ihyu3ELL";
		subject.Date2 = "m9fHgAUJ";
		subject.Charge = "M";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U3", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ReferenceIdentification = "j";
		subject.Date = "ihyu3ELL";
		subject.Date2 = "m9fHgAUJ";
		subject.Charge = "M";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ihyu3ELL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date2 = "m9fHgAUJ";
		subject.Charge = "M";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m9fHgAUJ", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date = "ihyu3ELL";
		subject.Charge = "M";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "vQ";
		subject.ReferenceIdentificationQualifier = "4V";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPayment = "U3";
		subject.Date = "ihyu3ELL";
		subject.Date2 = "m9fHgAUJ";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
