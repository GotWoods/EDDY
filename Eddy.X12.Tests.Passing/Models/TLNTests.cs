using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TLN*S*m*g*YT*Xq*y*9*8*Nx*OV*U*Sn*L*8*BV*yd*x*7*wf*R*3*E";

		var expected = new TLN_Tradeline()
		{
			AccountNumber = "S",
			YesNoConditionOrResponseCode = "m",
			YesNoConditionOrResponseCode2 = "g",
			TypeOfAccountCode = "YT",
			TypeOfAccountCode2 = "Xq",
			TypeOfCreditAccountCode = "y",
			Number = 9,
			LoanTypeCode = "8",
			RatingCode = "Nx",
			RatingRemarksCode = "OV",
			SourceOfDisclosureCode = "U",
			DateTimePeriodFormatQualifier = "Sn",
			DateTimePeriod = "L",
			MonetaryAmount = 8,
			RatingCode2 = "BV",
			DateTimePeriodFormatQualifier2 = "yd",
			DateTimePeriod2 = "x",
			MonetaryAmount2 = 7,
			RatingCode3 = "wf",
			YesNoConditionOrResponseCode3 = "R",
			Number2 = 3,
			Description = "E",
		};

		var actual = Map.MapObject<TLN_Tradeline>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Sn", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("Sn", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		subject.AccountNumber = "S";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("yd", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("yd", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new TLN_Tradeline();
		subject.AccountNumber = "S";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
