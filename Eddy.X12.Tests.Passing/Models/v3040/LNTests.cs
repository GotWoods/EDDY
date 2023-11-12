using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN*H*9*PO*V*W*1*4*k*Tm";

		var expected = new LN_LoanInformation()
		{
			ReferenceNumber = "H",
			MonetaryAmount = 9,
			DateTimePeriodFormatQualifier = "PO",
			DateTimePeriod = "V",
			FrequencyCode = "W",
			MonetaryAmount2 = 1,
			Percent = 4,
			YesNoConditionOrResponseCode = "k",
			LoanPurposeCode = "Tm",
		};

		var actual = Map.MapObject<LN_LoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "PO";
			subject.DateTimePeriod = "V";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "W";
			subject.MonetaryAmount2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceNumber = "H";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "PO";
			subject.DateTimePeriod = "V";
		}
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "W";
			subject.MonetaryAmount2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PO", "V", true)]
	[InlineData("PO", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceNumber = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FrequencyCode) || !string.IsNullOrEmpty(subject.FrequencyCode) || subject.MonetaryAmount2 > 0)
		{
			subject.FrequencyCode = "W";
			subject.MonetaryAmount2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("W", 1, true)]
	[InlineData("W", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredFrequencyCode(string frequencyCode, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LN_LoanInformation();
		//Required fields
		subject.ReferenceNumber = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "PO";
			subject.DateTimePeriod = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
