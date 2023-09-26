using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class GRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR*e*k*sq*O*J6*V*N7*N*7*8*2*9*C*C*mi*Y*2*p*D*6*5*z";

		var expected = new GR_GuaranteeResultDetail()
		{
			LoanTypeCode = "e",
			LoanStatusCode = "k",
			DateTimePeriodFormatQualifier = "sq",
			DateTimePeriod = "O",
			DateTimePeriodFormatQualifier2 = "J6",
			DateTimePeriod2 = "V",
			DateTimePeriodFormatQualifier3 = "N7",
			DateTimePeriod3 = "N",
			MonetaryAmount = 7,
			InterestRate = 8,
			LoanRateTypeCode = "2",
			InterestRate2 = 9,
			YesNoConditionOrResponseCode = "C",
			ReferenceIdentification = "C",
			DateTimePeriodFormatQualifier4 = "mi",
			DateTimePeriod4 = "Y",
			MonetaryAmount2 = 2,
			ReferenceIdentification2 = "p",
			YesNoConditionOrResponseCode2 = "D",
			Quantity = 6,
			YesNoConditionOrResponseCode3 = "5",
			GuaranteeAmountReductionCode = "z",
		};

		var actual = Map.MapObject<GR_GuaranteeResultDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sq", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J6", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDateTimePeriod2(string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N7", "N", true)]
	[InlineData("N7", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "2", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "2", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "mi";
			subject.DateTimePeriod4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mi", "Y", true)]
	[InlineData("mi", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "e";
		subject.LoanStatusCode = "k";
		subject.DateTimePeriodFormatQualifier = "sq";
		subject.DateTimePeriod = "O";
		subject.DateTimePeriodFormatQualifier2 = "J6";
		subject.DateTimePeriod2 = "V";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "N7";
			subject.DateTimePeriod3 = "N";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 8;
			subject.LoanRateTypeCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
