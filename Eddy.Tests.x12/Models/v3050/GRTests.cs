using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class GRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR*x*S*gZ*Y*V9*9*Nd*l*7*6*5*7*B*j*DI*8*7*c*J*8*p";

		var expected = new GR_GuaranteeResultDetail()
		{
			LoanTypeCode = "x",
			LoanStatusCode = "S",
			DateTimePeriodFormatQualifier = "gZ",
			DateTimePeriod = "Y",
			DateTimePeriodFormatQualifier2 = "V9",
			DateTimePeriod2 = "9",
			DateTimePeriodFormatQualifier3 = "Nd",
			DateTimePeriod3 = "l",
			MonetaryAmount = 7,
			InterestRate = 6,
			LoanRateTypeCode = "5",
			InterestRate2 = 7,
			YesNoConditionOrResponseCode = "B",
			ReferenceNumber = "j",
			DateTimePeriodFormatQualifier4 = "DI",
			DateTimePeriod4 = "8",
			MonetaryAmount2 = 7,
			ReferenceNumber2 = "c",
			YesNoConditionOrResponseCode2 = "J",
			Quantity = 8,
			YesNoConditionOrResponseCode3 = "p",
		};

		var actual = Map.MapObject<GR_GuaranteeResultDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gZ", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V9", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDateTimePeriod2(string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nd", "l", true)]
	[InlineData("Nd", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "5", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "5", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "DI";
			subject.DateTimePeriod4 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DI", "8", true)]
	[InlineData("DI", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new GR_GuaranteeResultDetail();
		//Required fields
		subject.LoanTypeCode = "x";
		subject.LoanStatusCode = "S";
		subject.DateTimePeriodFormatQualifier = "gZ";
		subject.DateTimePeriod = "Y";
		subject.DateTimePeriodFormatQualifier2 = "V9";
		subject.DateTimePeriod2 = "9";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Nd";
			subject.DateTimePeriod3 = "l";
		}
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 6;
			subject.LoanRateTypeCode = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
