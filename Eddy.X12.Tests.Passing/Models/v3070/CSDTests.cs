using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*mj*6Y*m*ft*3KClNd*8iWdNM*o*go*g";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "mj",
			ReferenceIdentificationQualifier = "6Y",
			ReferenceIdentification = "m",
			ShipmentMethodOfPayment = "ft",
			Date = "3KClNd",
			Date2 = "8iWdNM",
			Charge = "o",
			StandardCarrierAlphaCode = "go",
			ReferenceIdentification2 = "g",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mj", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ReferenceIdentification = "m";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date = "3KClNd";
		subject.Date2 = "8iWdNM";
		subject.Charge = "o";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6Y", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentification = "m";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date = "3KClNd";
		subject.Date2 = "8iWdNM";
		subject.Charge = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date = "3KClNd";
		subject.Date2 = "8iWdNM";
		subject.Charge = "o";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ft", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ReferenceIdentification = "m";
		subject.Date = "3KClNd";
		subject.Date2 = "8iWdNM";
		subject.Charge = "o";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3KClNd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ReferenceIdentification = "m";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date2 = "8iWdNM";
		subject.Charge = "o";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8iWdNM", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ReferenceIdentification = "m";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date = "3KClNd";
		subject.Charge = "o";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "mj";
		subject.ReferenceIdentificationQualifier = "6Y";
		subject.ReferenceIdentification = "m";
		subject.ShipmentMethodOfPayment = "ft";
		subject.Date = "3KClNd";
		subject.Date2 = "8iWdNM";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
