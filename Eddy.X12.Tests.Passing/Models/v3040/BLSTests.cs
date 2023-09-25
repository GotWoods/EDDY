using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*3G*MG*X*yOeAn5*mWba*ts";

		var expected = new BLS_BeginningSegmentForAssetSchedule()
		{
			TransactionSetPurposeCode = "3G",
			TransactionTypeCode = "MG",
			ReferenceNumber = "X",
			Date = "yOeAn5",
			Time = "mWba",
			AcknowledgmentType = "ts",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForAssetSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3G", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionTypeCode = "MG";
		subject.ReferenceNumber = "X";
		subject.Date = "yOeAn5";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MG", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "3G";
		subject.ReferenceNumber = "X";
		subject.Date = "yOeAn5";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "3G";
		subject.TransactionTypeCode = "MG";
		subject.Date = "yOeAn5";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yOeAn5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "3G";
		subject.TransactionTypeCode = "MG";
		subject.ReferenceNumber = "X";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
