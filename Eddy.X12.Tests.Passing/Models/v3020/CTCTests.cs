using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTC*lK*Yo*h*0d*zD*34*13*ip*59*38*Sm*7";

		var expected = new CTC_CarHireTransactionControl()
		{
			StandardCarrierAlphaCode = "lK",
			StandardCarrierAlphaCode2 = "Yo",
			CarHireDetailSummaryCode = "h",
			AccountTypeCode = "0d",
			TransactionSetPurposeCode = "zD",
			Century = 34,
			YearWithinCentury = 13,
			MonthOfTheYearCode = "ip",
			Century2 = 59,
			YearWithinCentury2 = 38,
			MonthOfTheYearCode2 = "Sm",
			AccountDescriptionCode = "7",
		};

		var actual = Map.MapObject<CTC_CarHireTransactionControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lK", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yo", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredCarHireDetailSummaryCode(string carHireDetailSummaryCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		subject.CarHireDetailSummaryCode = carHireDetailSummaryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0d", true)]
	public void Validation_RequiredAccountTypeCode(string accountTypeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		subject.AccountTypeCode = accountTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zD", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(34, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.YearWithinCentury = 13;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(13, true)]
	public void Validation_RequiredYearWithinCentury(int yearWithinCentury, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.MonthOfTheYearCode = "ip";
		//Test Parameters
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ip", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		//Required fields
		subject.StandardCarrierAlphaCode = "lK";
		subject.StandardCarrierAlphaCode2 = "Yo";
		subject.CarHireDetailSummaryCode = "h";
		subject.AccountTypeCode = "0d";
		subject.TransactionSetPurposeCode = "zD";
		subject.Century = 34;
		subject.YearWithinCentury = 13;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
