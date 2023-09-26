using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TXPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXP*i*n*8ZVMeU*m*H*j*E*Q*v*8";

		var expected = new TXP_TaxPayment()
		{
			TaxIdentificationNumber = "i",
			TaxPaymentTypeCode = "n",
			Date = "8ZVMeU",
			TaxInformationIdentificationNumber = "m",
			TaxAmount = "H",
			TaxInformationIdentificationNumber2 = "j",
			TaxAmount2 = "E",
			TaxInformationIdentificationNumber3 = "Q",
			TaxAmount3 = "v",
			TaxpayerVerification = "8",
		};

		var actual = Map.MapObject<TXP_TaxPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredTaxIdentificationNumber(string taxIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "n";
		subject.Date = "8ZVMeU";
		subject.TaxInformationIdentificationNumber = "m";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.Date = "8ZVMeU";
		subject.TaxInformationIdentificationNumber = "m";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8ZVMeU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.TaxPaymentTypeCode = "n";
		subject.TaxInformationIdentificationNumber = "m";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.TaxPaymentTypeCode = "n";
		subject.Date = "8ZVMeU";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.TaxPaymentTypeCode = "n";
		subject.Date = "8ZVMeU";
		subject.TaxInformationIdentificationNumber = "m";
		//Test Parameters
		subject.TaxAmount = taxAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "E", true)]
	[InlineData("j", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber2(string taxInformationIdentificationNumber2, string taxAmount2, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.TaxPaymentTypeCode = "n";
		subject.Date = "8ZVMeU";
		subject.TaxInformationIdentificationNumber = "m";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.TaxInformationIdentificationNumber2 = taxInformationIdentificationNumber2;
		subject.TaxAmount2 = taxAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber3) || !string.IsNullOrEmpty(subject.TaxAmount3))
		{
			subject.TaxInformationIdentificationNumber3 = "Q";
			subject.TaxAmount3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "v", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber3(string taxInformationIdentificationNumber3, string taxAmount3, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		//Required fields
		subject.TaxIdentificationNumber = "i";
		subject.TaxPaymentTypeCode = "n";
		subject.Date = "8ZVMeU";
		subject.TaxInformationIdentificationNumber = "m";
		subject.TaxAmount = "H";
		//Test Parameters
		subject.TaxInformationIdentificationNumber3 = taxInformationIdentificationNumber3;
		subject.TaxAmount3 = taxAmount3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxInformationIdentificationNumber2) || !string.IsNullOrEmpty(subject.TaxAmount2))
		{
			subject.TaxInformationIdentificationNumber2 = "j";
			subject.TaxAmount2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
