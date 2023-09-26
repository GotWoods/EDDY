using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*W*2*nq*0*g*9*8*T*a2*8T*N";

		var expected = new LN_LoanInformation()
		{
			ReferenceIdentification = "W",
			MonetaryAmount = 2,
			DateTimePeriodFormatQualifier = "nq",
			DateTimePeriod = "0",
			FrequencyCode = "g",
			MonetaryAmount2 = 9,
			PercentageAsDecimal = 8,
			YesNoConditionOrResponseCode = "T",
			LoanPurposeCode = "a2",
			LoanPaymentTypeCode = "8T",
			LoanRateTypeCode = "N",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "nq";
			subject.DateTimePeriod = "0";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "g";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "W";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "nq";
			subject.DateTimePeriod = "0";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "g";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nq", "0", true)]
	[InlineData("nq", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "W";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "g";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("g", 9, true)]
	[InlineData("g", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceIdentification = "W";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "nq";
			subject.DateTimePeriod = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
