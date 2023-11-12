using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*Jh*1w*O*fD*vXdcAOvo*NjUd0rzr*l*4l*C";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "Jh",
			ReferenceIdentificationQualifier = "1w",
			ReferenceIdentification = "O",
			ShipmentMethodOfPayment = "fD",
			Date = "vXdcAOvo",
			Date2 = "NjUd0rzr",
			AmountCharged = "l",
			StandardCarrierAlphaCode = "4l",
			ReferenceIdentification2 = "C",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jh", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "1w";
		subject.ReferenceIdentification = "O";
		subject.ShipmentMethodOfPayment = "fD";
		subject.AmountCharged = "l";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1w", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "Jh";
		subject.ReferenceIdentification = "O";
		subject.ShipmentMethodOfPayment = "fD";
		subject.AmountCharged = "l";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "Jh";
		subject.ReferenceIdentificationQualifier = "1w";
		subject.ShipmentMethodOfPayment = "fD";
		subject.AmountCharged = "l";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fD", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "Jh";
		subject.ReferenceIdentificationQualifier = "1w";
		subject.ReferenceIdentification = "O";
		subject.AmountCharged = "l";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "Jh";
		subject.ReferenceIdentificationQualifier = "1w";
		subject.ReferenceIdentification = "O";
		subject.ShipmentMethodOfPayment = "fD";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
