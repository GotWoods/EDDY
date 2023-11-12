using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSD*M5*ZF*k*Yu*qa0jO2ar*aEJMiYfJ*P*rE*G*PLsr*5m*3gWG*aA";

		var expected = new CSD_ConsolidatedShipmentInvoiceData()
		{
			SpecialHandlingCode = "M5",
			ReferenceIdentificationQualifier = "ZF",
			ReferenceIdentification = "k",
			ShipmentMethodOfPayment = "Yu",
			Date = "qa0jO2ar",
			Date2 = "aEJMiYfJ",
			AmountCharged = "P",
			StandardCarrierAlphaCode = "rE",
			ReferenceIdentification2 = "G",
			Time = "PLsr",
			TimeCode = "5m",
			Time2 = "3gWG",
			TimeCode2 = "aA",
		};

		var actual = Map.MapObject<CSD_ConsolidatedShipmentInvoiceData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M5", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZF", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yu", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PLsr", "qa0jO2ar", true)]
	[InlineData("PLsr", "", false)]
	[InlineData("", "qa0jO2ar", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}

        if (subject.Time != "")
            subject.TimeCode = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PLsr", "5m", true)]
	[InlineData("PLsr", "", false)]
	[InlineData("", "5m", false)]
	public void Validation_AllAreRequiredTimeCode(string time, string timeCode, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.Time = time;
		subject.TimeCode = timeCode;
		//A Requires B
		if (time != "")
			subject.Date = "qa0jO2ar";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.Time2) || !string.IsNullOrEmpty(subject.TimeCode2))
		{
			subject.Time2 = "3gWG";
			subject.TimeCode2 = "aA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3gWG", "aA", true)]
	[InlineData("3gWG", "", false)]
	[InlineData("", "aA", false)]
	public void Validation_AllAreRequiredTime2(string time2, string timeCode2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.Time2 = time2;
		subject.TimeCode2 = timeCode2;

        if (subject.Time2 != "")
            subject.Date2 = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3gWG", "aEJMiYfJ", true)]
	[InlineData("3gWG", "", false)]
	[InlineData("", "aEJMiYfJ", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new CSD_ConsolidatedShipmentInvoiceData();
		//Required fields
		subject.SpecialHandlingCode = "M5";
		subject.ReferenceIdentificationQualifier = "ZF";
		subject.ReferenceIdentification = "k";
		subject.ShipmentMethodOfPayment = "Yu";
		subject.AmountCharged = "P";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;

        if (subject.Time2 != "")
            subject.TimeCode2 = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
