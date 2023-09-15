using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*Q*u*6*d9h0H5*94C0*Ku*9*9*U*S*cuj*2";

		var expected = new FIR_FinancialInformation()
		{
			CodeListQualifierCode = "Q",
			IndustryCode = "u",
			MonetaryAmount = 6,
			Date = "d9h0H5",
			Time = "94C0",
			TimeCode = "Ku",
			Quantity = 9,
			Quantity2 = 9,
			CreditDebitFlagCode = "U",
			FinancialTransactionStatusCode = "S",
			CurrencyCode = "cuj",
			MonetaryAmount2 = 2,
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.IndustryCode = "u";
		subject.MonetaryAmount = 6;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "Q";
		subject.MonetaryAmount = 6;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "Q";
		subject.IndustryCode = "u";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ku", "94C0", true)]
	[InlineData("Ku", "", false)]
	[InlineData("", "94C0", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "Q";
		subject.IndustryCode = "u";
		subject.MonetaryAmount = 6;
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "cuj", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "cuj", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string currencyCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "Q";
		subject.IndustryCode = "u";
		subject.MonetaryAmount = 6;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
