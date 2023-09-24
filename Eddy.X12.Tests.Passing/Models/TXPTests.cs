using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TXPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXP*9*3*LpZ3RrxK*x*Y*2*q*V*t*h";

		var expected = new TXP_TaxPayment()
		{
			TaxIdentificationNumber = "9",
			TaxPaymentTypeCode = "3",
			Date = "LpZ3RrxK",
			TaxInformationIdentificationNumber = "x",
			TaxAmount = "Y",
			TaxInformationIdentificationNumber2 = "2",
			TaxAmount2 = "q",
			TaxInformationIdentificationNumber3 = "V",
			TaxAmount3 = "t",
			TaxpayerVerification = "h",
		};

		var actual = Map.MapObject<TXP_TaxPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredTaxIdentificationNumber(string taxIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxPaymentTypeCode = "3";
		subject.Date = "LpZ3RrxK";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = "Y";
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.Date = "LpZ3RrxK";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = "Y";
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LpZ3RrxK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.TaxPaymentTypeCode = "3";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = "Y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.TaxPaymentTypeCode = "3";
		subject.Date = "LpZ3RrxK";
		subject.TaxAmount = "Y";
		subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.TaxPaymentTypeCode = "3";
		subject.Date = "LpZ3RrxK";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = taxAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("2", "q", true)]
	[InlineData("", "q", false)]
	[InlineData("2", "", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber2(string taxInformationIdentificationNumber2, string taxAmount2, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.TaxPaymentTypeCode = "3";
		subject.Date = "LpZ3RrxK";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = "Y";
		subject.TaxInformationIdentificationNumber2 = taxInformationIdentificationNumber2;
		subject.TaxAmount2 = taxAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("V", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("V", "", false)]
	public void Validation_AllAreRequiredTaxInformationIdentificationNumber3(string taxInformationIdentificationNumber3, string taxAmount3, bool isValidExpected)
	{
		var subject = new TXP_TaxPayment();
		subject.TaxIdentificationNumber = "9";
		subject.TaxPaymentTypeCode = "3";
		subject.Date = "LpZ3RrxK";
		subject.TaxInformationIdentificationNumber = "x";
		subject.TaxAmount = "Y";
		subject.TaxInformationIdentificationNumber3 = taxInformationIdentificationNumber3;
		subject.TaxAmount3 = taxAmount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
