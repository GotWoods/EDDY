using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*yi*r5*n*Pf*JzuMZUPy*wxXTZ0to*p*RD*U*LCQJ*O7*uaET*GD";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "yi",
			ReferenceIdentificationQualifier = "r5",
			ReferenceIdentification = "n",
			ShipmentMethodOfPaymentCode = "Pf",
			Date = "JzuMZUPy",
			Date2 = "wxXTZ0to",
			AmountCharged = "p",
			StandardCarrierAlphaCode = "RD",
			ReferenceIdentification2 = "U",
			Time = "LCQJ",
			TimeCode = "O7",
			Time2 = "uaET",
			TimeCode2 = "GD",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yi", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r5", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pf", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LCQJ", "O7", true)]
	[InlineData("LCQJ", "", false)]
	[InlineData("", "O7", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.Time = time;
		subject.TimeCode = timeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}

        if (subject.Time != "")
            subject.Date = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LCQJ", "JzuMZUPy", true)]
	[InlineData("LCQJ", "", false)]
	[InlineData("", "JzuMZUPy", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "uaET";
			subject.TimeCode2 = "GD";
		}

        if (subject.Time != "")
            subject.TimeCode = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uaET", "GD", true)]
	[InlineData("uaET", "", false)]
	[InlineData("", "GD", false)]
	public void Validation_AllAreRequiredTime2(string time2, string timeCode2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.Time2 = time2;
		subject.TimeCode2 = timeCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}

        if (subject.Time2 != "")
            subject.Date2 = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uaET", "wxXTZ0to", true)]
	[InlineData("uaET", "", false)]
	[InlineData("", "wxXTZ0to", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "yi";
		subject.ReferenceIdentificationQualifier = "r5";
		subject.ReferenceIdentification = "n";
		subject.ShipmentMethodOfPaymentCode = "Pf";
		subject.AmountCharged = "p";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "LCQJ";
			subject.TimeCode = "O7";
		}

        if (subject.Time2 != "")
            subject.TimeCode2 = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
