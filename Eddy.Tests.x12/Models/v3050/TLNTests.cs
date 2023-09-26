using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TLN*B*4*0*Ol*1i*S*9*j*12*hm*i*Xu*r*8*GZ*sZ*5*6*nn*e*5*q";

		var expected = new TLN_Tradeline()
		{
			AccountNumber = "B",
			YesNoConditionOrResponseCode = "4",
			YesNoConditionOrResponseCode2 = "0",
			TypeOfAccountCode = "Ol",
			TypeOfAccountCode2 = "1i",
			TypeOfCreditAccountCode = "S",
			Number = 9,
			LoanTypeCode = "j",
			RatingCode = "12",
			RatingRemarksCode = "hm",
			SourceOfDisclosureCode = "i",
			DateTimePeriodFormatQualifier = "Xu",
			DateTimePeriod = "r",
			MonetaryAmount = 8,
			RatingCode2 = "GZ",
			DateTimePeriodFormatQualifier2 = "sZ",
			DateTimePeriod2 = "5",
			MonetaryAmount2 = 6,
			RatingCode3 = "nn",
			YesNoConditionOrResponseCode3 = "e",
			Number2 = 5,
			Description = "q",
		};

		var actual = Map.MapObject<TLN_Tradeline>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		//Test Parameters
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Xu";
			subject.DateTimePeriod = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "sZ";
			subject.DateTimePeriod2 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xu", "r", true)]
	[InlineData("Xu", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		subject.AccountNumber = "B";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "sZ";
			subject.DateTimePeriod2 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sZ", "5", true)]
	[InlineData("sZ", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		//Required fields
		subject.AccountNumber = "B";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Xu";
			subject.DateTimePeriod = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
