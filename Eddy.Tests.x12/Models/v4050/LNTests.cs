using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*8*1*fC*z*5*6*7*H*EU*jP*k";

		var expected = new LN_LoanInformation()
		{
			ReferenceIdentification = "8",
			MonetaryAmount = 1,
			DateTimePeriodFormatQualifier = "fC",
			DateTimePeriod = "z",
			FrequencyCode = "5",
			MonetaryAmount2 = 6,
			PercentageAsDecimal = 7,
			YesNoConditionOrResponseCode = "H",
			LoanPurposeCode = "EU",
			LoanPaymentTypeCode = "jP",
			LoanRateTypeCode = "k",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
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
			subject.DateTimePeriodFormatQualifier = "fC";
			subject.DateTimePeriod = "z";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "5";
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
		subject.ReferenceIdentification = "8";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fC";
			subject.DateTimePeriod = "z";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "5";
			subject.MonetaryAmount2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fC", "z", true)]
	[InlineData("fC", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "8";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "5";
			subject.MonetaryAmount2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5", 6, true)]
	[InlineData("5", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "8";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fC";
			subject.DateTimePeriod = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
