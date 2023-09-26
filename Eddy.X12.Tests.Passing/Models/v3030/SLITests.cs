using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLI*d*3*1*2*m*4t*5*K*6*s7*3*mw*2*6*7*7*4*M";

		var expected = new SLI_SpecificLoanInformation()
		{
			LoanTypeCode = "d",
			MonetaryAmount = 3,
			MonetaryAmount2 = 1,
			InterestRate = 2,
			LoanRateTypeCode = "m",
			DateTimePeriodFormatQualifier = "4t",
			DateTimePeriod = "5",
			ReferenceNumber = "K",
			YesNoConditionOrResponseCode = "6",
			DateTimePeriodFormatQualifier2 = "s7",
			DateTimePeriod2 = "3",
			DateTimePeriodFormatQualifier3 = "mw",
			DateTimePeriod3 = "2",
			MonetaryAmount3 = 6,
			Quantity = 7,
			Quantity2 = 7,
			Quantity3 = 4,
			YesNoConditionOrResponseCode2 = "M",
		};

		var actual = Map.MapObject<SLI_SpecificLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLoanRateTypeCode(string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4t", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s7", "3", true)]
	[InlineData("s7", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "mw";
			subject.DateTimePeriod3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mw", "2", true)]
	[InlineData("mw", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "d";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 1;
		subject.InterestRate = 2;
		subject.LoanRateTypeCode = "m";
		subject.DateTimePeriodFormatQualifier = "4t";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "s7";
			subject.DateTimePeriod2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
