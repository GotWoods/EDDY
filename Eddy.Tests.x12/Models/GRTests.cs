using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR*s*k*Fc*4*ib*E*MU*P*4*8*E*1*d*7*Pn*e*4*1*a*6*z*V";

		var expected = new GR_GuaranteeResultDetail()
		{
			LoanTypeCode = "s",
			LoanStatusCode = "k",
			DateTimePeriodFormatQualifier = "Fc",
			DateTimePeriod = "4",
			DateTimePeriodFormatQualifier2 = "ib",
			DateTimePeriod2 = "E",
			DateTimePeriodFormatQualifier3 = "MU",
			DateTimePeriod3 = "P",
			MonetaryAmount = 4,
			InterestRate = 8,
			LoanRateTypeCode = "E",
			InterestRate2 = 1,
			YesNoConditionOrResponseCode = "d",
			ReferenceIdentification = "7",
			DateTimePeriodFormatQualifier4 = "Pn",
			DateTimePeriod4 = "e",
			MonetaryAmount2 = 4,
			ReferenceIdentification2 = "1",
			YesNoConditionOrResponseCode2 = "a",
			Quantity = 6,
			YesNoConditionOrResponseCode3 = "z",
			GuaranteeAmountReductionCode = "V",
		};

		var actual = Map.MapObject<GR_GuaranteeResultDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.LoanTypeCode = loanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.LoanStatusCode = loanStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fc", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ib", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriod2 = "E";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDateTimePeriod2(string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = dateTimePeriod2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("MU", "P", true)]
	[InlineData("", "P", false)]
	[InlineData("MU", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "E", true)]
	[InlineData(0, "E", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		if (interestRate > 0)
		subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Pn", "e", true)]
	[InlineData("", "e", false)]
	[InlineData("Pn", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		subject.LoanTypeCode = "s";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "Fc";
		subject.DateTimePeriod = "4";
		subject.DateTimePeriodFormatQualifier2 = "ib";
		subject.DateTimePeriod2 = "E";
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
