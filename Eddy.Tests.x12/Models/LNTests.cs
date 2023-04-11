using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*R*6*PK*j*v*7*5*d*mm*W7*A";

		var expected = new LN_LoanInformation()
		{
			ReferenceIdentification = "R",
			MonetaryAmount = 6,
			DateTimePeriodFormatQualifier = "PK",
			DateTimePeriod = "j",
			FrequencyCode = "v",
			MonetaryAmount2 = 7,
			PercentageAsDecimal = 5,
			YesNoConditionOrResponseCode = "d",
			LoanPurposeCode = "mm",
			LoanPaymentTypeCode = "W7",
			LoanRateTypeCode = "A",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		subject.MonetaryAmount = 6;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		subject.ReferenceIdentification = "R";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("PK", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("PK", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		subject.ReferenceIdentification = "R";
		subject.MonetaryAmount = 6;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("v", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("v", 0, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		subject.ReferenceIdentification = "R";
		subject.MonetaryAmount = 6;
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
