using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class LN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN1*9*J*g*2*5*8*ld*1*z*k*M*2*4*8*4*7V*t*B*u*r*4*2*5";

		var expected = new LN1_LoanSpecificData()
		{
			MonetaryAmount = 9,
			LienPriorityCode = "J",
			RealEstateLoanTypeCode = "g",
			MonetaryAmount2 = 2,
			PercentageAsDecimal = 5,
			PercentageAsDecimal2 = 8,
			RateValueQualifier = "ld",
			MonetaryAmount3 = 1,
			RealEstateLoanSecurityInstrumentCode = "z",
			LoanDocumentationTypeCode = "k",
			LoanRateTypeCode = "M",
			YesNoConditionOrResponseCode = "2",
			AccountNumber = "4",
			PercentageAsDecimal3 = 8,
			PercentageAsDecimal4 = 4,
			DateTimePeriodFormatQualifier = "7V",
			DateTimePeriod = "t",
			DateTimePeriod2 = "B",
			DateTimePeriod3 = "u",
			DateTimePeriod4 = "r",
			DateTimePeriod5 = "4",
			MonetaryAmount4 = 2,
			MonetaryAmount5 = 5,
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
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "7V";
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "7V";
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "7V";
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ld", 1, true)]
	[InlineData("ld", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "7V";
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("7V", "t", "B", "u", "r", "4", true)]
	[InlineData("7V", "", "", "", "", "", false)]
	[InlineData("", "t", "B", "u", "r", "4", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod5 = dateTimePeriod5;
		//A Requires B
		if (dateTimePeriod != "")
			subject.DateTimePeriodFormatQualifier = "7V";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "7V";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "7V";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "7V";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "7V";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "7V", true)]
	[InlineData("t", "", false)]
	[InlineData("", "7V", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "7V", true)]
	[InlineData("B", "", false)]
	[InlineData("", "7V", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "7V", true)]
	[InlineData("u", "", false)]
	[InlineData("", "7V", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod4 = "r";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "7V", true)]
	[InlineData("r", "", false)]
	[InlineData("", "7V", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod5 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "7V", true)]
	[InlineData("4", "", false)]
	[InlineData("", "7V", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		//Required fields
		subject.MonetaryAmount = 9;
		subject.LienPriorityCode = "J";
		subject.RealEstateLoanTypeCode = "g";
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount3 > 0)
		{
			subject.RateValueQualifier = "ld";
			subject.MonetaryAmount3 = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriod = "t";
			subject.DateTimePeriod2 = "B";
			subject.DateTimePeriod3 = "u";
			subject.DateTimePeriod4 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
