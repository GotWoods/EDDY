using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSC*JP*EWy9lIAH*eVI9WrP8*yoLqA9rG";

		var expected = new BSC_BeginningSegmentForCommissionSalesReport()
		{
			TransactionSetPurposeCode = "JP",
			Date = "EWy9lIAH",
			Date2 = "eVI9WrP8",
			Date3 = "yoLqA9rG",
		};

		var actual = Map.MapObject<BSC_BeginningSegmentForCommissionSalesReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JP", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.Date = "EWy9lIAH";
		subject.Date2 = "eVI9WrP8";
		subject.Date3 = "yoLqA9rG";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EWy9lIAH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "JP";
		subject.Date2 = "eVI9WrP8";
		subject.Date3 = "yoLqA9rG";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eVI9WrP8", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "JP";
		subject.Date = "EWy9lIAH";
		subject.Date3 = "yoLqA9rG";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yoLqA9rG", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "JP";
		subject.Date = "EWy9lIAH";
		subject.Date2 = "eVI9WrP8";
		//Test Parameters
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
