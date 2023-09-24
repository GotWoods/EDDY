using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*A*q*6*OfRZx4*DRRd*VJ*5*4*R*x*eTt*9";

		var expected = new FIR_FinancialInformation()
		{
			CodeListQualifierCode = "A",
			IndustryCode = "q",
			MonetaryAmount = 6,
			Date = "OfRZx4",
			Time = "DRRd",
			TimeCode = "VJ",
			Quantity = 5,
			Quantity2 = 4,
			CreditDebitFlagCode = "R",
			FinancialTransactionStatusCode = "x",
			CurrencyCode = "eTt",
			MonetaryAmount2 = 9,
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.IndustryCode = "q";
		subject.MonetaryAmount = 6;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "eTt";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "A";
		subject.MonetaryAmount = 6;
		subject.IndustryCode = industryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "eTt";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "A";
		subject.IndustryCode = "q";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "eTt";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VJ", "DRRd", true)]
	[InlineData("VJ", "", false)]
	[InlineData("", "DRRd", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "A";
		subject.IndustryCode = "q";
		subject.MonetaryAmount = 6;
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.CurrencyCode = "eTt";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("eTt", 9, true)]
	[InlineData("eTt", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredCurrencyCode(string currencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.CodeListQualifierCode = "A";
		subject.IndustryCode = "q";
		subject.MonetaryAmount = 6;
		subject.CurrencyCode = currencyCode;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
