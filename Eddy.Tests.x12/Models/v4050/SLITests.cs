using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLI*U*8*7*7*q*5y*5*S*W*co*6*LN*v*6*7*8*7*J*h*UU*5*H";

		var expected = new SLI_SpecificLoanInformation()
		{
			LoanTypeCode = "U",
			MonetaryAmount = 8,
			MonetaryAmount2 = 7,
			InterestRate = 7,
			LoanRateTypeCode = "q",
			DateTimePeriodFormatQualifier = "5y",
			DateTimePeriod = "5",
			ReferenceIdentification = "S",
			YesNoConditionOrResponseCode = "W",
			DateTimePeriodFormatQualifier2 = "co",
			DateTimePeriod2 = "6",
			DateTimePeriodFormatQualifier3 = "LN",
			DateTimePeriod3 = "v",
			MonetaryAmount3 = 6,
			Quantity = 7,
			Quantity2 = 8,
			Quantity3 = 7,
			YesNoConditionOrResponseCode2 = "J",
			YesNoConditionOrResponseCode3 = "h",
			DateTimePeriodFormatQualifier4 = "UU",
			DateTimePeriod4 = "5",
			PaymentMethodTypeCode = "H",
		};

		var actual = Map.MapObject<SLI_SpecificLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredLoanRateTypeCode(string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5y", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
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
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("co", "6", true)]
	[InlineData("co", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LN", "v", true)]
	[InlineData("LN", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "UU";
			subject.DateTimePeriod4 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UU", "5", true)]
	[InlineData("UU", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "U";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 7;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "q";
		subject.DateTimePeriodFormatQualifier = "5y";
		subject.DateTimePeriod = "5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "co";
			subject.DateTimePeriod2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "LN";
			subject.DateTimePeriod3 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
