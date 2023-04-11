using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*T*8KhhOZNB*0*AfBuqTbFwUCJZZ7O*3Ud5OydC*pa6";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "T",
			Date = "8KhhOZNB",
			Amount = "0",
			MICRNumber = "AfBuqTbFwUCJZZ7O",
			Date2 = "3Ud5OydC",
			CurrencyCode = "pa6",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "8KhhOZNB";
		subject.Amount = "0";
		subject.CurrencyCode = "pa6";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8KhhOZNB", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "T";
		subject.Amount = "0";
		subject.CurrencyCode = "pa6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "T";
		subject.Date = "8KhhOZNB";
		subject.CurrencyCode = "pa6";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pa6", true)]
	public void Validatation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "T";
		subject.Date = "8KhhOZNB";
		subject.Amount = "0";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
