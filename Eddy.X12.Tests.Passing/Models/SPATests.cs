using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPA*g8*Gi*y*9*2*uIq*ZiM*0Zn*bk*q*K";

		var expected = new SPA_StatusOfProductOrActivity()
		{
			StatusCode = "g8",
			DateTimePeriodFormatQualifier = "Gi",
			DateTimePeriod = "y",
			AmountQualifierCode = "9",
			MonetaryAmount = 2,
			StatusReasonCode = "uIq",
			StatusReasonCode2 = "ZiM",
			StatusReasonCode3 = "0Zn",
			AgencyQualifierCode = "bk",
			ProductDescriptionCode = "q",
			SourceSubqualifier = "K",
		};

		var actual = Map.MapObject<SPA_StatusOfProductOrActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g8", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new SPA_StatusOfProductOrActivity();
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Gi", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("Gi", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SPA_StatusOfProductOrActivity();
		subject.StatusCode = "g8";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("9", 2, true)]
	[InlineData("", 2, false)]
	[InlineData("9", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SPA_StatusOfProductOrActivity();
		subject.StatusCode = "g8";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("bk", "q", true)]
	[InlineData("", "q", false)]
	[InlineData("bk", "", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new SPA_StatusOfProductOrActivity();
		subject.StatusCode = "g8";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
