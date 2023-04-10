using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSC*2D*2t8RP6Ri*3ST0UM8K*h7CFlfqZ";

		var expected = new BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation()
		{
			TransactionSetPurposeCode = "2D",
			Date = "2t8RP6Ri",
			Date2 = "3ST0UM8K",
			Date3 = "h7CFlfqZ",
		};

		var actual = Map.MapObject<BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2D", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation();
		subject.Date = "2t8RP6Ri";
		subject.Date2 = "3ST0UM8K";
		subject.Date3 = "h7CFlfqZ";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2t8RP6Ri", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation();
		subject.TransactionSetPurposeCode = "2D";
		subject.Date2 = "3ST0UM8K";
		subject.Date3 = "h7CFlfqZ";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3ST0UM8K", true)]
	public void Validatation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation();
		subject.TransactionSetPurposeCode = "2D";
		subject.Date = "2t8RP6Ri";
		subject.Date3 = "h7CFlfqZ";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h7CFlfqZ", true)]
	public void Validatation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation();
		subject.TransactionSetPurposeCode = "2D";
		subject.Date = "2t8RP6Ri";
		subject.Date2 = "3ST0UM8K";
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
