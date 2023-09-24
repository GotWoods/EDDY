using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*IPegynl9*x*n*H*0*fI*Bz4s5BTG*67a*a6c*f7";

		var expected = new F11_Status()
		{
			Date = "IPegynl9",
			ReferenceIdentification = "x",
			ReferenceIdentification2 = "n",
			Amount = "H",
			Amount2 = "0",
			StatusCode = "fI",
			Date2 = "Bz4s5BTG",
			DeclineAmendReasonCode = "67a",
			CurrencyCode = "a6c",
			ReferenceIdentificationQualifier = "f7",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IPegynl9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceIdentification = "x";
		subject.StatusCode = "fI";
		subject.Date2 = "Bz4s5BTG";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.StatusCode = "fI";
		subject.Date2 = "Bz4s5BTG";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "f7", true)]
	[InlineData("n", "", false)]
	[InlineData("", "f7", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.ReferenceIdentification = "x";
		subject.StatusCode = "fI";
		subject.Date2 = "Bz4s5BTG";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "a6c", true)]
	[InlineData("H", "", false)]
	[InlineData("", "a6c", false)]
	public void Validation_AllAreRequiredAmount(string amount, string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.ReferenceIdentification = "x";
		subject.StatusCode = "fI";
		subject.Date2 = "Bz4s5BTG";
		subject.Amount = amount;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "H", true)]
	[InlineData("0", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBAmount2(string amount2, string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.ReferenceIdentification = "x";
		subject.StatusCode = "fI";
		subject.Date2 = "Bz4s5BTG";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fI", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.ReferenceIdentification = "x";
		subject.Date2 = "Bz4s5BTG";
		subject.StatusCode = statusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bz4s5BTG", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "IPegynl9";
		subject.ReferenceIdentification = "x";
		subject.StatusCode = "fI";
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "n";
			subject.ReferenceIdentificationQualifier = "f7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "H";
			subject.CurrencyCode = "a6c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
