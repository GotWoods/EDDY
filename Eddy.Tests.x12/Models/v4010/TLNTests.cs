using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TLN*3*B*j*qw*f1*M*9*m*xF*Ug*x*Pr*y*5*i4*I6*M*5*Or*b*2*U";

		var expected = new TLN_Tradeline()
		{
			AccountNumber = "3",
			YesNoConditionOrResponseCode = "B",
			YesNoConditionOrResponseCode2 = "j",
			TypeOfAccountCode = "qw",
			TypeOfAccountCode2 = "f1",
			TypeOfCreditAccountCode = "M",
			Number = 9,
			LoanTypeCode = "m",
			RatingCode = "xF",
			RatingRemarksCode = "Ug",
			SourceOfDisclosureCode = "x",
			DateTimePeriodFormatQualifier = "Pr",
			DateTimePeriod = "y",
			MonetaryAmount = 5,
			RatingCode2 = "i4",
			DateTimePeriodFormatQualifier2 = "I6",
			DateTimePeriod2 = "M",
			MonetaryAmount2 = 5,
			RatingCode3 = "Or",
			YesNoConditionOrResponseCode3 = "b",
			Number2 = 2,
			Description = "U",
		};

		var actual = Map.MapObject<TLN_Tradeline>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		//Test Parameters
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Pr";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "I6";
			subject.DateTimePeriod2 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pr", "y", true)]
	[InlineData("Pr", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		subject.AccountNumber = "3";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "I6";
			subject.DateTimePeriod2 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I6", "M", true)]
	[InlineData("I6", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		subject.AccountNumber = "3";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Pr";
			subject.DateTimePeriod = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
