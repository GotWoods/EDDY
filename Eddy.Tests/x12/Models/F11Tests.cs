using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*3EMUWpR9*M*T*S*w*Hk*qMzecZJH*8j1*bK1*Ab";

		var expected = new F11_Status()
		{
			Date = "3EMUWpR9",
			ReferenceIdentification = "M",
			ReferenceIdentification2 = "T",
			Amount = "S",
			Amount2 = "w",
			StatusCode = "Hk",
			Date2 = "qMzecZJH",
			DeclineAmendReasonCode = "8j1",
			CurrencyCode = "bK1",
			ReferenceIdentificationQualifier = "Ab",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3EMUWpR9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceIdentification = "M";
		subject.StatusCode = "Hk";
		subject.Date2 = "qMzecZJH";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.StatusCode = "Hk";
		subject.Date2 = "qMzecZJH";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("T", "Ab", true)]
	[InlineData("", "Ab", false)]
	[InlineData("T", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.ReferenceIdentification = "M";
		subject.StatusCode = "Hk";
		subject.Date2 = "qMzecZJH";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "bK1", true)]
	[InlineData("", "bK1", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredAmount(string amount, string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.ReferenceIdentification = "M";
		subject.StatusCode = "Hk";
		subject.Date2 = "qMzecZJH";
		subject.Amount = amount;
		subject.CurrencyCode = currencyCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "S", true)]
	[InlineData("w", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.ReferenceIdentification = "M";
		subject.StatusCode = "Hk";
		subject.Date2 = "qMzecZJH";
		subject.Amount2 = amount2;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hk", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.ReferenceIdentification = "M";
		subject.Date2 = "qMzecZJH";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qMzecZJH", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3EMUWpR9";
		subject.ReferenceIdentification = "M";
		subject.StatusCode = "Hk";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
