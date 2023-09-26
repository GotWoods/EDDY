using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*M*1*Vu*X*q*6*2*g*75*jx*m";

		var expected = new LN_LoanInformation()
		{
			ReferenceIdentification = "M",
			MonetaryAmount = 1,
			DateTimePeriodFormatQualifier = "Vu",
			DateTimePeriod = "X",
			FrequencyCode = "q",
			MonetaryAmount2 = 6,
			Percent = 2,
			YesNoConditionOrResponseCode = "g",
			LoanPurposeCode = "75",
			LoanPaymentTypeCode = "jx",
			LoanRateTypeCode = "m",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vu";
			subject.DateTimePeriod = "X";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "q";
			subject.MonetaryAmount2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "M";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vu";
			subject.DateTimePeriod = "X";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "q";
			subject.MonetaryAmount2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vu", "X", true)]
	[InlineData("Vu", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "M";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "q";
			subject.MonetaryAmount2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("q", 6, true)]
	[InlineData("q", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "M";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vu";
			subject.DateTimePeriod = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
