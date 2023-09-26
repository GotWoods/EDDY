using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class GRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR*J*2*Pe*w*MT*S*Ug*X*6*6*4*3*e*S*DF*U*3*l*n*7*f";

		var expected = new GR_GuaranteeResultDetail()
		{
			LoanTypeCode = "J",
			LoanStatusCode = "2",
			DateTimePeriodFormatQualifier = "Pe",
			DateTimePeriod = "w",
			DateTimePeriodFormatQualifier2 = "MT",
			DateTimePeriod2 = "S",
			DateTimePeriodFormatQualifier3 = "Ug",
			DateTimePeriod3 = "X",
			MonetaryAmount = 6,
			InterestRate = 6,
			LoanRateTypeCode = "4",
			InterestRate2 = 3,
			YesNoConditionOrResponseCode = "e",
			ReferenceIdentification = "S",
			DateTimePeriodFormatQualifier4 = "DF",
			DateTimePeriod4 = "U",
			MonetaryAmount2 = 3,
			ReferenceIdentification2 = "l",
			YesNoConditionOrResponseCode2 = "n",
			Quantity = 7,
			YesNoConditionOrResponseCode3 = "f",
		};

		var actual = Map.MapObject<GR_GuaranteeResultDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
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
		subject.LoanTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pe", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MT", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredDateTimePeriod2(string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ug", "X", true)]
	[InlineData("Ug", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "4", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "4", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DF";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DF", "U", true)]
	[InlineData("DF", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "J";
		subject.LoanStatusCode = "2";
		subject.DateTimePeriodFormatQualifier = "Pe";
		subject.DateTimePeriod = "w";
		subject.DateTimePeriodFormatQualifier2 = "MT";
		subject.DateTimePeriod2 = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Ug";
			subject.DateTimePeriod3 = "X";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
