using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*F*TEctU4Bg*4*5Nx6L6LfCfARdQaH*H43RaIuw*qjg";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "F",
			Date = "TEctU4Bg",
			Amount = "4",
			MICRNumber = "5Nx6L6LfCfARdQaH",
			Date2 = "H43RaIuw",
			CurrencyCode = "qjg",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "TEctU4Bg";
		subject.Amount = "4";
		subject.CurrencyCode = "qjg";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TEctU4Bg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "F";
		subject.Amount = "4";
		subject.CurrencyCode = "qjg";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "F";
		subject.Date = "TEctU4Bg";
		subject.CurrencyCode = "qjg";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qjg", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "F";
		subject.Date = "TEctU4Bg";
		subject.Amount = "4";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
