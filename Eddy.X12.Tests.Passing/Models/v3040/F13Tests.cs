using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*K*1nBwvk*s*PgOs9v3BjTq9nbC8*25t3Wb*pUX";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "K",
			Date = "1nBwvk",
			Amount = "s",
			MICRNumber = "PgOs9v3BjTq9nbC8",
			Date2 = "25t3Wb",
			CurrencyCode = "pUX",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "1nBwvk";
		subject.Amount = "s";
		subject.CurrencyCode = "pUX";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1nBwvk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "K";
		subject.Amount = "s";
		subject.CurrencyCode = "pUX";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "K";
		subject.Date = "1nBwvk";
		subject.CurrencyCode = "pUX";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pUX", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "K";
		subject.Date = "1nBwvk";
		subject.Amount = "s";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
