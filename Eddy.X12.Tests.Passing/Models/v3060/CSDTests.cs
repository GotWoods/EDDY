using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*JD*05*F*6m*bDTDh8*C42qRS*6*tV*l";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "JD",
			ReferenceIdentificationQualifier = "05",
			ReferenceIdentification = "F",
			ShipmentMethodOfPayment = "6m",
			Date = "bDTDh8",
			Date2 = "C42qRS",
			Charge = "6",
			StandardCarrierAlphaCode = "tV",
			ReferenceIdentification2 = "l",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JD", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "05";
		subject.ReferenceIdentification = "F";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date = "bDTDh8";
		subject.Date2 = "C42qRS";
		subject.Charge = "6";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentification = "F";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date = "bDTDh8";
		subject.Date2 = "C42qRS";
		subject.Charge = "6";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentificationQualifier = "05";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date = "bDTDh8";
		subject.Date2 = "C42qRS";
		subject.Charge = "6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6m", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentificationQualifier = "05";
		subject.ReferenceIdentification = "F";
		subject.Date = "bDTDh8";
		subject.Date2 = "C42qRS";
		subject.Charge = "6";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bDTDh8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentificationQualifier = "05";
		subject.ReferenceIdentification = "F";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date2 = "C42qRS";
		subject.Charge = "6";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C42qRS", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentificationQualifier = "05";
		subject.ReferenceIdentification = "F";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date = "bDTDh8";
		subject.Charge = "6";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "JD";
		subject.ReferenceIdentificationQualifier = "05";
		subject.ReferenceIdentification = "F";
		subject.ShipmentMethodOfPayment = "6m";
		subject.Date = "bDTDh8";
		subject.Date2 = "C42qRS";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
