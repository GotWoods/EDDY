using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTC*Ch*iN*Q*Ui*2U*3785*jE*6434*iW*q";

		var expected = new CTC_CarHireTransactionControl()
		{
			StandardCarrierAlphaCode = "Ch",
			StandardCarrierAlphaCode2 = "iN",
			CarHireDetailSummaryCode = "Q",
			AccountTypeCode = "Ui",
			TransactionSetPurposeCode = "2U",
			Year = 3785,
			MonthOfTheYearCode = "jE",
			Year2 = 6434,
			MonthOfTheYearCode2 = "iW",
			AccountDescriptionCode = "q",
		};

		var actual = Map.MapObject<CTC_CarHireTransactionControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ch", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iN", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredCarHireDetailSummaryCode(string carHireDetailSummaryCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		subject.CarHireDetailSummaryCode = carHireDetailSummaryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ui", true)]
	public void Validation_RequiredAccountTypeCode(string accountTypeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		subject.AccountTypeCode = accountTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2U", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3785, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.MonthOfTheYearCode = "jE";
		if (year > 0)
		subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jE", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6434, "iW", true)]
	[InlineData(0, "iW", false)]
	[InlineData(6434, "", false)]
	public void Validation_AllAreRequiredYear2(int year2, string monthOfTheYearCode2, bool isValidExpected)
	{
		var subject = new CTC_CarHireTransactionControl();
		subject.StandardCarrierAlphaCode = "Ch";
		subject.StandardCarrierAlphaCode2 = "iN";
		subject.CarHireDetailSummaryCode = "Q";
		subject.AccountTypeCode = "Ui";
		subject.TransactionSetPurposeCode = "2U";
		subject.Year = 3785;
		subject.MonthOfTheYearCode = "jE";
		if (year2 > 0)
		subject.Year2 = year2;
		subject.MonthOfTheYearCode2 = monthOfTheYearCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
