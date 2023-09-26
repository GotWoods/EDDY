using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLI*X*8*3*7*z*7R*z*l*9*kf*L*W3*r*7*6*6*9*m*L*RN*V*i";

		var expected = new SLI_SpecificLoanInformation()
		{
			LoanTypeCode = "X",
			MonetaryAmount = 8,
			MonetaryAmount2 = 3,
			InterestRate = 7,
			LoanRateTypeCode = "z",
			DateTimePeriodFormatQualifier = "7R",
			DateTimePeriod = "z",
			ReferenceIdentification = "l",
			YesNoConditionOrResponseCode = "9",
			DateTimePeriodFormatQualifier2 = "kf",
			DateTimePeriod2 = "L",
			DateTimePeriodFormatQualifier3 = "W3",
			DateTimePeriod3 = "r",
			MonetaryAmount3 = 7,
			Quantity = 6,
			Quantity2 = 6,
			Quantity3 = 9,
			YesNoConditionOrResponseCode2 = "m",
			YesNoConditionOrResponseCode3 = "L",
			DateTimePeriodFormatQualifier4 = "RN",
			DateTimePeriod4 = "V",
			PaymentMethodCode = "i",
		};

		var actual = Map.MapObject<SLI_SpecificLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
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
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
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
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredLoanRateTypeCode(string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7R", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kf", "L", true)]
	[InlineData("kf", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W3", "r", true)]
	[InlineData("W3", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "RN";
			subject.DateTimePeriod4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RN", "V", true)]
	[InlineData("RN", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "X";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "z";
		subject.DateTimePeriodFormatQualifier = "7R";
		subject.DateTimePeriod = "z";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "kf";
			subject.DateTimePeriod2 = "L";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "W3";
			subject.DateTimePeriod3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
