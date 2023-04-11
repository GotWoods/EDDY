using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN1*8*t*k*9*6*3*lG*9*c*8*O*Y*n*9*5*WX*A*R*M*H*J*9*5";

		var expected = new LN1_LoanSpecificData()
		{
			MonetaryAmount = 8,
			LienPriorityCode = "t",
			RealEstateLoanTypeCode = "k",
			MonetaryAmount2 = 9,
			PercentageAsDecimal = 6,
			PercentageAsDecimal2 = 3,
			RateValueQualifier = "lG",
			MonetaryAmount3 = 9,
			RealEstateLoanSecurityInstrumentCode = "c",
			LoanDocumentationTypeCode = "8",
			LoanRateTypeCode = "O",
			YesNoConditionOrResponseCode = "Y",
			AccountNumber = "n",
			PercentageAsDecimal3 = 9,
			PercentageAsDecimal4 = 5,
			DateTimePeriodFormatQualifier = "WX",
			DateTimePeriod = "A",
			DateTimePeriod2 = "R",
			DateTimePeriod3 = "M",
			DateTimePeriod4 = "H",
			DateTimePeriod5 = "J",
			MonetaryAmount4 = 9,
			MonetaryAmount5 = 5,
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
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.RealEstateLoanTypeCode = "k";
		subject.LienPriorityCode = lienPriorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("lG", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("lG", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount3 > 0)
		subject.MonetaryAmount3 = monetaryAmount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", "", "", "", "", true)]
	[InlineData("WX", "A", "", "", "", "", false)]
    [InlineData("","A", "", "", "", "", true)]
    [InlineData("WX", "", "", "", "", "", true)]

    public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod5 = dateTimePeriod5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "WX", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "WX", true)]
	[InlineData("R", "", false)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "WX", true)]
	[InlineData("M", "", false)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "WX", true)]
	[InlineData("H", "", false)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "WX", true)]
	[InlineData("J", "", false)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LN1_LoanSpecificData();
		subject.MonetaryAmount = 8;
		subject.LienPriorityCode = "t";
		subject.RealEstateLoanTypeCode = "k";
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
