using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*iY*eC*8*Nz*Yx3EGR*b2dKJS*m*1E*v";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "iY",
			ReferenceNumberQualifier = "eC",
			ReferenceNumber = "8",
			ShipmentMethodOfPayment = "Nz",
			Date = "Yx3EGR",
			Date2 = "b2dKJS",
			Charge = "m",
			StandardCarrierAlphaCode = "1E",
			ReferenceNumber2 = "v",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iY", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceNumberQualifier = "eC";
		subject.ReferenceNumber = "8";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date = "Yx3EGR";
		subject.Date2 = "b2dKJS";
		subject.Charge = "m";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eC", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumber = "8";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date = "Yx3EGR";
		subject.Date2 = "b2dKJS";
		subject.Charge = "m";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumberQualifier = "eC";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date = "Yx3EGR";
		subject.Date2 = "b2dKJS";
		subject.Charge = "m";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nz", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumberQualifier = "eC";
		subject.ReferenceNumber = "8";
		subject.Date = "Yx3EGR";
		subject.Date2 = "b2dKJS";
		subject.Charge = "m";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yx3EGR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumberQualifier = "eC";
		subject.ReferenceNumber = "8";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date2 = "b2dKJS";
		subject.Charge = "m";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b2dKJS", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumberQualifier = "eC";
		subject.ReferenceNumber = "8";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date = "Yx3EGR";
		subject.Charge = "m";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "iY";
		subject.ReferenceNumberQualifier = "eC";
		subject.ReferenceNumber = "8";
		subject.ShipmentMethodOfPayment = "Nz";
		subject.Date = "Yx3EGR";
		subject.Date2 = "b2dKJS";
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
