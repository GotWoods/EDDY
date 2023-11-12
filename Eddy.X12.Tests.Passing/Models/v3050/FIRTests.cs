using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*N*g*7*554swh*GBhh*2r*9*5*A*Z*V5M*5";

		var expected = new FIR_FinancialInformation()
		{
			CodeListQualifierCode = "N",
			FinancialInformationCode = "g",
			MonetaryAmount = 7,
			Date = "554swh",
			Time = "GBhh",
			TimeCode = "2r",
			Quantity = 9,
			Quantity2 = 5,
			CreditDebitFlagCode = "A",
			FinancialTransactionStatusCode = "Z",
			CurrencyCode = "V5M",
			MonetaryAmount2 = 5,
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialInformationCode = "g";
		subject.MonetaryAmount = 7;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "V5M";
			subject.MonetaryAmount2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredFinancialInformationCode(string financialInformationCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "N";
		subject.MonetaryAmount = 7;
		subject.FinancialInformationCode = financialInformationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "V5M";
			subject.MonetaryAmount2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "N";
		subject.FinancialInformationCode = "g";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "V5M";
			subject.MonetaryAmount2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2r", "GBhh", true)]
	[InlineData("2r", "", false)]
	[InlineData("", "GBhh", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "N";
		subject.FinancialInformationCode = "g";
		subject.MonetaryAmount = 7;
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "V5M";
			subject.MonetaryAmount2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("V5M", 5, true)]
	[InlineData("V5M", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredCurrencyCode(string currencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "N";
		subject.FinancialInformationCode = "g";
		subject.MonetaryAmount = 7;
		subject.CurrencyCode = currencyCode;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
