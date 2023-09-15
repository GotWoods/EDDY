using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*iBEGw72p*L*R*7*C*xa*U3Zzhzl6*Uu8*WV9*fb";

		var expected = new F11_Status()
		{
			Date = "iBEGw72p",
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "R",
			Amount = "7",
			Amount2 = "C",
			StatusCode = "xa",
			Date2 = "U3Zzhzl6",
			DeclineAmendReasonCode = "Uu8",
			CurrencyCode = "WV9",
			ReferenceIdentificationQualifier = "fb",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iBEGw72p", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceIdentification = "L";
		subject.StatusCode = "xa";
		subject.Date2 = "U3Zzhzl6";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.StatusCode = "xa";
		subject.Date2 = "U3Zzhzl6";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "fb", true)]
	[InlineData("R", "", false)]
	[InlineData("", "fb", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.ReferenceIdentification = "L";
		subject.StatusCode = "xa";
		subject.Date2 = "U3Zzhzl6";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "WV9", true)]
	[InlineData("7", "", false)]
	[InlineData("", "WV9", false)]
	public void Validation_AllAreRequiredAmount(string amount, string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.ReferenceIdentification = "L";
		subject.StatusCode = "xa";
		subject.Date2 = "U3Zzhzl6";
		subject.Amount = amount;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "7", true)]
	[InlineData("C", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBAmount2(string amount2, string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.ReferenceIdentification = "L";
		subject.StatusCode = "xa";
		subject.Date2 = "U3Zzhzl6";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xa", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.ReferenceIdentification = "L";
		subject.Date2 = "U3Zzhzl6";
		subject.StatusCode = statusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U3Zzhzl6", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "iBEGw72p";
		subject.ReferenceIdentification = "L";
		subject.StatusCode = "xa";
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "R";
			subject.ReferenceIdentificationQualifier = "fb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "7";
			subject.CurrencyCode = "WV9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
