using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*DSBv0S*6*P*T*r*hf*pblRxs*1t8*26e";

		var expected = new F11_Status()
		{
			Date = "DSBv0S",
			ReferenceNumber = "6",
			ReferenceNumber2 = "P",
			Amount = "T",
			Amount2 = "r",
			StatusCode = "hf",
			Date2 = "pblRxs",
			DeclineAmendReasonCode = "1t8",
			CurrencyCode = "26e",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DSBv0S", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceNumber = "6";
		subject.ReferenceNumber2 = "P";
		subject.Amount = "T";
		subject.StatusCode = "hf";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = "26e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber2 = "P";
		subject.Amount = "T";
		subject.StatusCode = "hf";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = "26e";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber = "6";
		subject.Amount = "T";
		subject.StatusCode = "hf";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = "26e";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber = "6";
		subject.ReferenceNumber2 = "P";
		subject.StatusCode = "hf";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = "26e";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hf", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber = "6";
		subject.ReferenceNumber2 = "P";
		subject.Amount = "T";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = "26e";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pblRxs", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber = "6";
		subject.ReferenceNumber2 = "P";
		subject.Amount = "T";
		subject.StatusCode = "hf";
		subject.CurrencyCode = "26e";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("26e", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "DSBv0S";
		subject.ReferenceNumber = "6";
		subject.ReferenceNumber2 = "P";
		subject.Amount = "T";
		subject.StatusCode = "hf";
		subject.Date2 = "pblRxs";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
