using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TXPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXP*s*y*jfT32x*0*l*d*X*i*6*u";

		var expected = new TXP_TaxPayment()
		{
			TaxIdentificationNumber = "s",
			TaxPaymentTypeCode = "y",
			Date = "jfT32x",
			AmountQualifierCode = "0",
			TaxAmount = "l",
			AmountQualifierCode2 = "d",
			TaxAmount2 = "X",
			AmountQualifierCode3 = "i",
			TaxAmount3 = "6",
			TaxpayerVerification = "u",
		};

		var actual = Map.MapObject<TXP_TaxPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTaxIdentificationNumber(string taxIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "y";
		subject.Date = "jfT32x";
		subject.AmountQualifierCode = "0";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.Date = "jfT32x";
		subject.AmountQualifierCode = "0";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jfT32x", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.TaxPaymentTypeCode = "y";
		subject.AmountQualifierCode = "0";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.TaxPaymentTypeCode = "y";
		subject.Date = "jfT32x";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.TaxPaymentTypeCode = "y";
		subject.Date = "jfT32x";
		subject.AmountQualifierCode = "0";
		//Test Parameters
		subject.TaxAmount = taxAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "X", true)]
	[InlineData("d", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredAmountQualifierCode2(string amountQualifierCode2, string taxAmount2, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.TaxPaymentTypeCode = "y";
		subject.Date = "jfT32x";
		subject.AmountQualifierCode = "0";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.AmountQualifierCode2 = amountQualifierCode2;
		subject.TaxAmount2 = taxAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.AmountQualifierCode3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.AmountQualifierCode3 = "i";
			subject.TaxAmount3 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "6", true)]
	[InlineData("i", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredAmountQualifierCode3(string amountQualifierCode3, string taxAmount3, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "s";
		subject.TaxPaymentTypeCode = "y";
		subject.Date = "jfT32x";
		subject.AmountQualifierCode = "0";
		subject.TaxAmount = "l";
		//Test Parameters
		subject.AmountQualifierCode3 = amountQualifierCode3;
		subject.TaxAmount3 = taxAmount3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.AmountQualifierCode2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.AmountQualifierCode2 = "d";
			subject.TaxAmount2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
