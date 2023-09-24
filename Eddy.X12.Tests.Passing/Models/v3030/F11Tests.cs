using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*V6tW6t*W*l*0*b*qg*F1Wyku*1HD*J7Y";

		var expected = new F11_Status()
		{
			Date = "V6tW6t",
			ReferenceNumber = "W",
			ReferenceNumber2 = "l",
			Amount = "0",
			Amount2 = "b",
			StatusCode = "qg",
			Date2 = "F1Wyku",
			DeclineAmendReasonCode = "1HD",
			CurrencyCode = "J7Y",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V6tW6t", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "l";
		subject.Amount = "0";
		subject.StatusCode = "qg";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = "J7Y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber2 = "l";
		subject.Amount = "0";
		subject.StatusCode = "qg";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = "J7Y";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber = "W";
		subject.Amount = "0";
		subject.StatusCode = "qg";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = "J7Y";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "l";
		subject.StatusCode = "qg";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = "J7Y";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qg", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "l";
		subject.Amount = "0";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = "J7Y";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F1Wyku", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "l";
		subject.Amount = "0";
		subject.StatusCode = "qg";
		subject.CurrencyCode = "J7Y";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J7Y", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "V6tW6t";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "l";
		subject.Amount = "0";
		subject.StatusCode = "qg";
		subject.Date2 = "F1Wyku";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
