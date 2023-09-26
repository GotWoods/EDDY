using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLI*R*8*3*7*B*DB*H*R*b*7k*F*0Q*G*2*4*1*9*j*y*6T*R*z";

		var expected = new SLI_SpecificLoanInformation()
		{
			LoanTypeCode = "R",
			MonetaryAmount = 8,
			MonetaryAmount2 = 3,
			InterestRate = 7,
			LoanRateTypeCode = "B",
			DateTimePeriodFormatQualifier = "DB",
			DateTimePeriod = "H",
			ReferenceIdentification = "R",
			YesNoConditionOrResponseCode = "b",
			DateTimePeriodFormatQualifier2 = "7k",
			DateTimePeriod2 = "F",
			DateTimePeriodFormatQualifier3 = "0Q",
			DateTimePeriod3 = "G",
			MonetaryAmount3 = 2,
			Quantity = 4,
			Quantity2 = 1,
			Quantity3 = 9,
			YesNoConditionOrResponseCode2 = "j",
			YesNoConditionOrResponseCode3 = "y",
			DateTimePeriodFormatQualifier4 = "6T",
			DateTimePeriod4 = "R",
			PaymentMethodCode = "z",
		};

		var actual = Map.MapObject<SLI_SpecificLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
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
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
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
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
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
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredLoanRateTypeCode(string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DB", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7k", "F", true)]
	[InlineData("7k", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0Q", "G", true)]
	[InlineData("0Q", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "6T";
			subject.DateTimePeriod4 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6T", "R", true)]
	[InlineData("6T", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		subject.InterestRate = 7;
		subject.LoanRateTypeCode = "B";
		subject.DateTimePeriodFormatQualifier = "DB";
		subject.DateTimePeriod = "H";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "7k";
			subject.DateTimePeriod2 = "F";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "0Q";
			subject.DateTimePeriod3 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
