using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*hl*5P*4*Fq*VYHPRheg*ZyPmPEPc*A*iD*z*hxPe*xR*fSG5*Kb";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "hl",
			ReferenceIdentificationQualifier = "5P",
			ReferenceIdentification = "4",
			ShipmentMethodOfPaymentCode = "Fq",
			Date = "VYHPRheg",
			Date2 = "ZyPmPEPc",
			AmountCharged = "A",
			StandardCarrierAlphaCode = "iD",
			ReferenceIdentification2 = "z",
			Time = "hxPe",
			TimeCode = "xR",
			Time2 = "fSG5",
			TimeCode2 = "Kb",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hl", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5P", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fq", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hxPe", "VYHPRheg", true)]
	[InlineData("hxPe", "", false)]
	[InlineData("", "VYHPRheg", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}

        if (subject.Time != "")
            subject.TimeCode = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hxPe", "xR", true)]
	[InlineData("hxPe", "", false)]
	[InlineData("", "xR", false)]
	public void Validation_AllAreRequiredTimeCode(string time, string timeCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.Time = time;
		subject.TimeCode = timeCode;
		//A Requires B
		if (time != "")
			subject.Date = "VYHPRheg";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "fSG5";
			subject.TimeCode2 = "Kb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fSG5", "Kb", true)]
	[InlineData("fSG5", "", false)]
	[InlineData("", "Kb", false)]
	public void Validation_AllAreRequiredTime2(string time2, string timeCode2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.Time2 = time2;
		subject.TimeCode2 = timeCode2;

        if (subject.Time2 != "")
            subject.Date2 = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fSG5", "ZyPmPEPc", true)]
	[InlineData("fSG5", "", false)]
	[InlineData("", "ZyPmPEPc", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hl";
		subject.ReferenceIdentificationQualifier = "5P";
		subject.ReferenceIdentification = "4";
		subject.ShipmentMethodOfPaymentCode = "Fq";
		subject.AmountCharged = "A";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;

        if (subject.Time2 != "")
            subject.TimeCode2 = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
