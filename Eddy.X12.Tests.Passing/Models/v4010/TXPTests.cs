using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TXPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXP*T*S*IrSj23gS*G*B*e*o*y*9*d";

		var expected = new TXP_TaxPayment()
		{
			TaxIdentificationNumber = "T",
			TaxPaymentTypeCode = "S",
			Date = "IrSj23gS",
			TaxInformationIdentificationNumber = "G",
			TaxAmount = "B",
			TaxInformationIdentificationNumber2 = "e",
			TaxAmount2 = "o",
			TaxInformationIdentificationNumber3 = "y",
			TaxAmount3 = "9",
			TaxpayerVerification = "d",
		};

		var actual = Map.MapObject<TXP_TaxPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTaxIdentificationNumber(string taxIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "S";
		subject.Date = "IrSj23gS";
		subject.TaxInformationIdentificationNumber = "G";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.Date = "IrSj23gS";
		subject.TaxInformationIdentificationNumber = "G";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IrSj23gS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.TaxPaymentTypeCode = "S";
		subject.TaxInformationIdentificationNumber = "G";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.TaxPaymentTypeCode = "S";
		subject.Date = "IrSj23gS";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.TaxPaymentTypeCode = "S";
		subject.Date = "IrSj23gS";
		subject.TaxInformationIdentificationNumber = "G";
		//Test Parameters
		subject.TaxAmount = taxAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "o", true)]
	[InlineData("e", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber2(string taxInformationIdentificationNumber2, string taxAmount2, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.TaxPaymentTypeCode = "S";
		subject.Date = "IrSj23gS";
		subject.TaxInformationIdentificationNumber = "G";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.TaxInformationIdentificationNumber2 = taxInformationIdentificationNumber2;
		subject.TaxAmount2 = taxAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "y";
			subject.TaxAmount3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "9", true)]
	[InlineData("y", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber3(string taxInformationIdentificationNumber3, string taxAmount3, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "T";
		subject.TaxPaymentTypeCode = "S";
		subject.Date = "IrSj23gS";
		subject.TaxInformationIdentificationNumber = "G";
		subject.TaxAmount = "B";
		//Test Parameters
		subject.TaxInformationIdentificationNumber3 = taxInformationIdentificationNumber3;
		subject.TaxAmount3 = taxAmount3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "e";
			subject.TaxAmount2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
