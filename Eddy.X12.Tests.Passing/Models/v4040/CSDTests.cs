using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*RQ*TO*q*R7*BIhj3uGg*hK98LwkU*o*iv*i";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "RQ",
			ReferenceIdentificationQualifier = "TO",
			ReferenceIdentification = "q",
			ShipmentMethodOfPayment = "R7",
			Date = "BIhj3uGg",
			Date2 = "hK98LwkU",
			Charge = "o",
			StandardCarrierAlphaCode = "iv",
			ReferenceIdentification2 = "i",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RQ", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "TO";
		subject.ReferenceIdentification = "q";
		subject.ShipmentMethodOfPayment = "R7";
		subject.Charge = "o";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TO", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "RQ";
		subject.ReferenceIdentification = "q";
		subject.ShipmentMethodOfPayment = "R7";
		subject.Charge = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "RQ";
		subject.ReferenceIdentificationQualifier = "TO";
		subject.ShipmentMethodOfPayment = "R7";
		subject.Charge = "o";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R7", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "RQ";
		subject.ReferenceIdentificationQualifier = "TO";
		subject.ReferenceIdentification = "q";
		subject.Charge = "o";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "RQ";
		subject.ReferenceIdentificationQualifier = "TO";
		subject.ReferenceIdentification = "q";
		subject.ShipmentMethodOfPayment = "R7";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
