using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN1*8*c*F*9*6*9*w8*2*L*n*o*c*b*5*5*V2*b*m*8*U*H*9*8";

		var expected = new LN1_LoanSpecificData()
		{
			MonetaryAmount = 8,
			LienPriorityCode = "c",
			RealEstateLoanTypeCode = "F",
			MonetaryAmount2 = 9,
			Percent = 6,
			Percent2 = 9,
			RateValueQualifier = "w8",
			MonetaryAmount3 = 2,
			RealEstateLoanSecurityInstrumentCode = "L",
			LoanDocumentationTypeCode = "n",
			LoanRateTypeCode = "o",
			YesNoConditionOrResponseCode = "c",
			AccountNumber = "b",
			Percent3 = 5,
			Percent4 = 5,
			DateTimePeriodFormatQualifier = "V2",
			DateTimePeriod = "b",
			DateTimePeriod2 = "m",
			DateTimePeriod3 = "8",
			DateTimePeriod4 = "U",
			DateTimePeriod5 = "H",
			MonetaryAmount4 = 9,
			MonetaryAmount5 = 8,
		};

		var actual = Map.MapObject<LN1_LoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V2";
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V2";
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V2";
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w8", 2, true)]
	[InlineData("w8", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "V2";
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("V2", "b", "m", "8", "U", "H", true)]
	[InlineData("V2", "", "", "", "", "", false)]
	[InlineData("", "b", "m", "8", "U", "H", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod5 = dateTimePeriod5;
		//A Requires B
		if (dateTimePeriod != "")
			subject.DateTimePeriodFormatQualifier = "V2";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "V2";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "V2";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "V2";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "V2";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "V2", true)]
	[InlineData("b", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "V2", true)]
	[InlineData("m", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "V2", true)]
	[InlineData("8", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "V2", true)]
	[InlineData("U", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod5 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "V2", true)]
	[InlineData("H", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "c";
		subject.RealEstateLoanTypeCode = "F";
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "w8";
			subject.MonetaryAmount3 = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriod = "b";
			subject.DateTimePeriod2 = "m";
			subject.DateTimePeriod3 = "8";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
