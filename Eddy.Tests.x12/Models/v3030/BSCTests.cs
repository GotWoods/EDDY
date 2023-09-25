using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSC*4y*hrcyTF*OHunsJ*yr4ulQ";

		var expected = new BSC_BeginningSegmentForCommissionSalesReport()
		{
			TransactionSetPurposeCode = "4y",
			Date = "hrcyTF",
			Date2 = "OHunsJ",
			Date3 = "yr4ulQ",
		};

		var actual = Map.MapObject<BSC_BeginningSegmentForCommissionSalesReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4y", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.Date = "hrcyTF";
		subject.Date2 = "OHunsJ";
		subject.Date3 = "yr4ulQ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hrcyTF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "4y";
		subject.Date2 = "OHunsJ";
		subject.Date3 = "yr4ulQ";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OHunsJ", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "4y";
		subject.Date = "hrcyTF";
		subject.Date3 = "yr4ulQ";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yr4ulQ", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSC_BeginningSegmentForCommissionSalesReport();
		//Required fields
		subject.TransactionSetPurposeCode = "4y";
		subject.Date = "hrcyTF";
		subject.Date2 = "OHunsJ";
		//Test Parameters
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
