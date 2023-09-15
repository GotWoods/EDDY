using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*PtK7RlOf*K*h*o*4*RL*VE5tmFJL*POV*kPQ*b8";

		var expected = new F11_Status()
		{
			Date = "PtK7RlOf",
			ReferenceIdentification = "K",
			ReferenceIdentification2 = "h",
			Amount = "o",
			Amount2 = "4",
			StatusCode = "RL",
			Date2 = "VE5tmFJL",
			DeclineAmendReasonCode = "POV",
			CurrencyCode = "kPQ",
			ReferenceIdentificationQualifier = "b8",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PtK7RlOf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceIdentification = "K";
		subject.StatusCode = "RL";
		subject.Date2 = "VE5tmFJL";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.StatusCode = "RL";
		subject.Date2 = "VE5tmFJL";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "b8", true)]
	[InlineData("h", "", false)]
	[InlineData("", "b8", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.ReferenceIdentification = "K";
		subject.StatusCode = "RL";
		subject.Date2 = "VE5tmFJL";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "kPQ", true)]
	[InlineData("o", "", false)]
	[InlineData("", "kPQ", false)]
	public void Validation_AllAreRequiredAmount(string amount, string currencyCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.ReferenceIdentification = "K";
		subject.StatusCode = "RL";
		subject.Date2 = "VE5tmFJL";
		subject.Amount = amount;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "o", true)]
	[InlineData("4", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBAmount2(string amount2, string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.ReferenceIdentification = "K";
		subject.StatusCode = "RL";
		subject.Date2 = "VE5tmFJL";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RL", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.ReferenceIdentification = "K";
		subject.Date2 = "VE5tmFJL";
		subject.StatusCode = statusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VE5tmFJL", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "PtK7RlOf";
		subject.ReferenceIdentification = "K";
		subject.StatusCode = "RL";
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "h";
			subject.ReferenceIdentificationQualifier = "b8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.Amount) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.Amount = "o";
			subject.CurrencyCode = "kPQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
