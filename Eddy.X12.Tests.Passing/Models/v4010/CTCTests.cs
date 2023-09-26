using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTC*00*mB*I*H4*Ho*7827*18*7248*Mt*d";

		var expected = new CTC_CarHireTransactionControl()
		{
			StandardCarrierAlphaCode = "00",
			StandardCarrierAlphaCode2 = "mB",
			CarHireDetailSummaryCode = "I",
			AccountTypeCode = "H4",
			TransactionSetPurposeCode = "Ho",
			Year = 7827,
			MonthOfTheYearCode = "18",
			Year2 = 7248,
			MonthOfTheYearCode2 = "Mt",
			AccountDescriptionCode = "d",
		};

		var actual = Map.MapObject<CTC_CarHireTransactionControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("00", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredCarHireDetailSummaryCode(string carHireDetailSummaryCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		subject.CarHireDetailSummaryCode = carHireDetailSummaryCode;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H4", true)]
	public void Validation_RequiredAccountTypeCode(string accountTypeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		subject.AccountTypeCode = accountTypeCode;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ho", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7827, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("18", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		//If one filled, all required
		if(subject.Year2 > 0 || subject.Year2 > 0 || !string.IsNullOrEmpty(subject.MonthOfTheYearCode2))
		{
			subject.Year2 = 7248;
			subject.MonthOfTheYearCode2 = "Mt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7248, "Mt", true)]
	[InlineData(7248, "", false)]
	[InlineData(0, "Mt", false)]
	public void Validation_AllAreRequiredYear2(int year2, string monthOfTheYearCode2, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "00";
		subject.StandardCarrierAlphaCode2 = "mB";
		subject.CarHireDetailSummaryCode = "I";
		subject.AccountTypeCode = "H4";
		subject.TransactionSetPurposeCode = "Ho";
		subject.Year = 7827;
		subject.MonthOfTheYearCode = "18";
		//Test Parameters
		if (year2 > 0) 
			subject.Year2 = year2;
		subject.MonthOfTheYearCode2 = monthOfTheYearCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
