using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN1*1*8*x*8*2*4*9T*1*P*s*1*b*s*9*3*dR*E*g*r*t*l*1*1";

		var expected = new LN1_LoanSpecificData()
		{
			MonetaryAmount = 1,
			LienPriorityCode = "8",
			RealEstateLoanTypeCode = "x",
			MonetaryAmount2 = 8,
			Percent = 2,
			Percent2 = 4,
			RateValueQualifier = "9T",
			MonetaryAmount3 = 1,
			RealEstateLoanSecurityInstrumentCode = "P",
			LoanDocumentationTypeCode = "s",
			LoanRateTypeCode = "1",
			YesNoConditionOrResponseCode = "b",
			AccountNumber = "s",
			Percent3 = 9,
			Percent4 = 3,
			DateTimePeriodFormatQualifier = "dR",
			DateTimePeriod = "E",
			DateTimePeriod2 = "g",
			DateTimePeriod3 = "r",
			DateTimePeriod4 = "t",
			DateTimePeriod5 = "l",
			MonetaryAmount4 = 1,
			MonetaryAmount5 = 1,
		};

		var actual = Map.MapObject<LN1_LoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9T", 1, true)]
	[InlineData("9T", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "dR", true)]
	[InlineData("E", "", false)]
	[InlineData("", "dR", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "dR", true)]
	[InlineData("g", "", false)]
	[InlineData("", "dR", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "dR", true)]
	[InlineData("r", "", false)]
	[InlineData("", "dR", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "dR", true)]
	[InlineData("t", "", false)]
	[InlineData("", "dR", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "dR", true)]
	[InlineData("l", "", false)]
	[InlineData("", "dR", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 1;
		subject.LienPriorityCode = "8";
		subject.RealEstateLoanTypeCode = "x";
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "9T";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
