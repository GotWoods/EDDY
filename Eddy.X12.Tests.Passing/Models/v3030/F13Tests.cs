using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*s*0RxF1Q*P*nJUUOPx3SXfJjjSC*AVazkO*qzl";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "s",
			Date = "0RxF1Q",
			Amount = "P",
			MICRNumber = "nJUUOPx3SXfJjjSC",
			Date2 = "AVazkO",
			CurrencyCode = "qzl",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "0RxF1Q";
		subject.Amount = "P";
		subject.CurrencyCode = "qzl";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0RxF1Q", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "s";
		subject.Amount = "P";
		subject.CurrencyCode = "qzl";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "s";
		subject.Date = "0RxF1Q";
		subject.CurrencyCode = "qzl";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qzl", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "s";
		subject.Date = "0RxF1Q";
		subject.Amount = "P";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
