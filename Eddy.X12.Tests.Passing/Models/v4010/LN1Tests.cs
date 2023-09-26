using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN1*9*m*3*4*5*6*yv*4*t*o*o*1*k*6*7*V5*0*K*D*P*B*7*7";

		var expected = new LN1_LoanSpecificData()
		{
			MonetaryAmount = 9,
			LienPriorityCode = "m",
			RealEstateLoanTypeCode = "3",
			MonetaryAmount2 = 4,
			Percent = 5,
			Percent2 = 6,
			RateValueQualifier = "yv",
			MonetaryAmount3 = 4,
			RealEstateLoanSecurityInstrumentCode = "t",
			LoanDocumentationTypeCode = "o",
			LoanRateTypeCode = "o",
			YesNoConditionOrResponseCode = "1",
			AccountNumber = "k",
			Percent3 = 6,
			Percent4 = 7,
			DateTimePeriodFormatQualifier = "V5",
			DateTimePeriod = "0",
			DateTimePeriod2 = "K",
			DateTimePeriod3 = "D",
			DateTimePeriod4 = "P",
			DateTimePeriod5 = "B",
			MonetaryAmount4 = 7,
			MonetaryAmount5 = 7,
		};

		var actual = Map.MapObject<LN1_LoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V5";
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V5";
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V5";
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("yv", 4, true)]
	[InlineData("yv", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V5";
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("V5", "0", "K", "D", "P", "B", true)]
	[InlineData("V5", "", "", "", "", "", false)]
	[InlineData("", "0", "K", "D", "P", "B", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod5 = dateTimePeriod5;
		//A Requires B
		if (dateTimePeriod != "")
			subject.DateTimePeriodFormatQualifier = "V5";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "V5";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "V5";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "V5";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "V5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "V5", true)]
	[InlineData("0", "", false)]
	[InlineData("", "V5", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "V5", true)]
	[InlineData("K", "", false)]
	[InlineData("", "V5", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "V5", true)]
	[InlineData("D", "", false)]
	[InlineData("", "V5", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod4 = "P";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "V5", true)]
	[InlineData("P", "", false)]
	[InlineData("", "V5", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "V5", true)]
	[InlineData("B", "", false)]
	[InlineData("", "V5", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "m";
		subject.RealEstateLoanTypeCode = "3";
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "yv";
			subject.MonetaryAmount3 = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriod = "0";
			subject.DateTimePeriod2 = "K";
			subject.DateTimePeriod3 = "D";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
