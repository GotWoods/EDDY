using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*8*o*2*y2XPgRZa*TQaP*u8*5*7*e*T*vTq*8";

		var expected = new FIR_FinancialInformation()
		{
			CodeListQualifierCode = "8",
			IndustryCode = "o",
			MonetaryAmount = 2,
			Date = "y2XPgRZa",
			Time = "TQaP",
			TimeCode = "u8",
			Quantity = 5,
			Quantity2 = 7,
			CreditDebitFlagCode = "e",
			FinancialTransactionStatusCode = "T",
			CurrencyCode = "vTq",
			MonetaryAmount2 = 8,
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.IndustryCode = "o";
		subject.MonetaryAmount = 2;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "8";
		subject.MonetaryAmount = 2;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = "o";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "TQaP", true)]
	[InlineData("u8", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = "o";
		subject.MonetaryAmount = 2;
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "vTq", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string currencyCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = "o";
		subject.MonetaryAmount = 2;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		subject.CurrencyCode = currencyCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
