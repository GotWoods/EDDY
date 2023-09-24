using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*PZAQqb*t*r*w*t*Lm*GcGQ93*5fa*fnF*TO";

		var expected = new F11_Status()
		{
			Date = "PZAQqb",
			ReferenceIdentification = "t",
			ReferenceIdentification2 = "r",
			Amount = "w",
			Amount2 = "t",
			StatusCode = "Lm",
			Date2 = "GcGQ93",
			DeclineAmendReasonCode = "5fa",
			CurrencyCode = "fnF",
			ReferenceIdentificationQualifier = "TO",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PZAQqb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceIdentification = "t";
		subject.StatusCode = "Lm";
		subject.Date2 = "GcGQ93";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.StatusCode = "Lm";
		subject.Date2 = "GcGQ93";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "TO", true)]
	[InlineData("r", "", false)]
	[InlineData("", "TO", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.ReferenceIdentification = "t";
		subject.StatusCode = "Lm";
		subject.Date2 = "GcGQ93";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "fnF", true)]
	[InlineData("w", "", false)]
	[InlineData("", "fnF", false)]
	public void Validation_AllAreRequiredAmount(string amount, string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.ReferenceIdentification = "t";
		subject.StatusCode = "Lm";
		subject.Date2 = "GcGQ93";
		subject.Amount = amount;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "w", true)]
	[InlineData("t", "", false)]
	[InlineData("", "w", true)]
	public void Validation_ARequiresBAmount2(string amount2, string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.ReferenceIdentification = "t";
		subject.StatusCode = "Lm";
		subject.Date2 = "GcGQ93";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lm", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.ReferenceIdentification = "t";
		subject.Date2 = "GcGQ93";
		subject.StatusCode = statusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GcGQ93", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PZAQqb";
		subject.ReferenceIdentification = "t";
		subject.StatusCode = "Lm";
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "r";
			subject.ReferenceIdentificationQualifier = "TO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "w";
			subject.CurrencyCode = "fnF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
