using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*K*J*7*jdiAFaH8*zuxv*HR*3*4*y*Y*kLI*8";

		var expected = new FIR_FinancialInformation()
		{
			CodeListQualifierCode = "K",
			IndustryCode = "J",
			MonetaryAmount = 7,
			Date = "jdiAFaH8",
			Time = "zuxv",
			TimeCode = "HR",
			Quantity = 3,
			Quantity2 = 4,
			CreditDebitFlagCode = "y",
			FinancialTransactionStatusCode = "Y",
			CurrencyCode = "kLI",
			MonetaryAmount2 = 8,
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.IndustryCode = "J";
		subject.MonetaryAmount = 7;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "K";
		subject.MonetaryAmount = 7;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "K";
		subject.IndustryCode = "J";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HR", "zuxv", true)]
	[InlineData("HR", "", false)]
	[InlineData("", "zuxv", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "K";
		subject.IndustryCode = "J";
		subject.MonetaryAmount = 7;
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "kLI", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "kLI", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string currencyCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "K";
		subject.IndustryCode = "J";
		subject.MonetaryAmount = 7;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
