using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*hT*6E*M*nd*XGPDwvnn*2VFhG353*R*pS*e*T40s*yW*jp8W*gw";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "hT",
			ReferenceIdentificationQualifier = "6E",
			ReferenceIdentification = "M",
			ShipmentMethodOfPayment = "nd",
			Date = "XGPDwvnn",
			Date2 = "2VFhG353",
			AmountCharged = "R",
			StandardCarrierAlphaCode = "pS",
			ReferenceIdentification2 = "e",
			Time = "T40s",
			TimeCode = "yW",
			Time2 = "jp8W",
			TimeCode2 = "gw",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hT", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6E", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nd", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T40s", "XGPDwvnn", true)]
	[InlineData("T40s", "", false)]
	[InlineData("", "XGPDwvnn", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}

        if (subject.Time != "")
            subject.TimeCode = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T40s", "yW", true)]
	[InlineData("T40s", "", false)]
	[InlineData("", "yW", false)]
	public void Validation_AllAreRequiredTimeCode(string time, string timeCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.Time = time;
		subject.TimeCode = timeCode;
		//A Requires B
		if (time != "")
			subject.Date = "XGPDwvnn";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "jp8W";
			subject.TimeCode2 = "gw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jp8W", "gw", true)]
	[InlineData("jp8W", "", false)]
	[InlineData("", "gw", false)]
	public void Validation_AllAreRequiredTime2(string time2, string timeCode2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.Time2 = time2;
		subject.TimeCode2 = timeCode2;

        if (subject.Time2 != "")
            subject.Date2 = "AAAAAAAA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jp8W", "2VFhG353", true)]
	[InlineData("jp8W", "", false)]
	[InlineData("", "2VFhG353", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "hT";
		subject.ReferenceIdentificationQualifier = "6E";
		subject.ReferenceIdentification = "M";
		subject.ShipmentMethodOfPayment = "nd";
		subject.AmountCharged = "R";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;

        if (subject.Time2 != "")
            subject.TimeCode2 = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
