using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class GRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR*Z*2*Cc*D*o7*o*Ae*J*2*3*3*1*d*u*eT*l*1*c*2*4*m*A";

		var expected = new GR_GuaranteeResultDetail()
		{
			LoanTypeCode = "Z",
			LoanStatusCode = "2",
			DateTimePeriodFormatQualifier = "Cc",
			DateTimePeriod = "D",
			DateTimePeriodFormatQualifier2 = "o7",
			DateTimePeriod2 = "o",
			DateTimePeriodFormatQualifier3 = "Ae",
			DateTimePeriod3 = "J",
			MonetaryAmount = 2,
			InterestRate = 3,
			LoanRateTypeCode = "3",
			InterestRate2 = 1,
			YesNoConditionOrResponseCode = "d",
			ReferenceIdentification = "u",
			DateTimePeriodFormatQualifier4 = "eT",
			DateTimePeriod4 = "l",
			MonetaryAmount2 = 1,
			ReferenceIdentification2 = "c",
			YesNoConditionOrResponseCode2 = "2",
			Quantity = 4,
			YesNoConditionOrResponseCode3 = "m",
			GuaranteeAmountReductionCode = "A",
		};

		var actual = Map.MapObject<GR_GuaranteeResultDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cc", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o7", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredDateTimePeriod2(string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ae", "J", true)]
	[InlineData("Ae", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "3", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "3", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "eT";
			subject.DateTimePeriod4 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eT", "l", true)]
	[InlineData("eT", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "Z";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Cc";
		subject.DateTimePeriod = "D";
		subject.DateTimePeriodFormatQualifier2 = "o7";
		subject.DateTimePeriod2 = "o";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ae";
			subject.DateTimePeriod3 = "J";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 3;
			subject.LoanRateTypeCode = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
