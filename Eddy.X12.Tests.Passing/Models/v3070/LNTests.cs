using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*f*7*qY*Q*y*3*7*X*qO*h2*R";

		var expected = new LN_LoanInformation()
		{
			ReferenceIdentification = "f",
			MonetaryAmount = 7,
			DateTimePeriodFormatQualifier = "qY",
			DateTimePeriod = "Q",
			FrequencyCode = "y",
			MonetaryAmount2 = 3,
			Percent = 7,
			YesNoConditionOrResponseCode = "X",
			LoanPurposeCode = "qO",
			LoanPaymentTypeCode = "h2",
			LoanRateTypeCode = "R",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "qY";
			subject.DateTimePeriod = "Q";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "y";
			subject.MonetaryAmount2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "f";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "qY";
			subject.DateTimePeriod = "Q";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "y";
			subject.MonetaryAmount2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qY", "Q", true)]
	[InlineData("qY", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "f";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "y";
			subject.MonetaryAmount2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y", 3, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "f";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "qY";
			subject.DateTimePeriod = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
