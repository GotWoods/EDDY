using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*JV*JU*i*0N*rNcnrgRF*UIvgW3ah*a*bb*z*mcLo*dP*qFHN*V0";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "JV",
			ReferenceIdentificationQualifier = "JU",
			ReferenceIdentification = "i",
			ShipmentMethodOfPaymentCode = "0N",
			Date = "rNcnrgRF",
			Date2 = "UIvgW3ah",
			AmountCharged = "a",
			StandardCarrierAlphaCode = "bb",
			ReferenceIdentification2 = "z",
			Time = "mcLo",
			TimeCode = "dP",
			Time2 = "qFHN",
			TimeCode2 = "V0",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JV", true)]
	public void Validatation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JU", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0N", true)]
	public void Validatation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.AmountCharged = "a";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validatation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mcLo", "dP", true)]
	[InlineData("", "dP", false)]
	[InlineData("mcLo", "", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.Time = time;
		subject.TimeCode = timeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "rNcnrgRF", true)]
	[InlineData("mcLo", "", false)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.Time = time;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("qFHN", "V0", true)]
	[InlineData("", "V0", false)]
	[InlineData("qFHN", "", false)]
	public void Validation_AllAreRequiredTime2(string time2, string timeCode2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.Time2 = time2;
		subject.TimeCode2 = timeCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "UIvgW3ah", true)]
	[InlineData("qFHN", "", false)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		subject.SpecialHandlingCode = "JV";
		subject.ReferenceIdentificationQualifier = "JU";
		subject.ReferenceIdentification = "i";
		subject.ShipmentMethodOfPaymentCode = "0N";
		subject.AmountCharged = "a";
		subject.Time2 = time2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
