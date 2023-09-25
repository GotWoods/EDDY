using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*w4*ls*t*da0WALNc*XUuX*ta";

		var expected = new BLS_BeginningSegmentForAssetSchedule()
		{
			TransactionSetPurposeCode = "w4",
			TransactionTypeCode = "ls",
			ReferenceIdentification = "t",
			Date = "da0WALNc",
			Time = "XUuX",
			AcknowledgmentType = "ta",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForAssetSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w4", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionTypeCode = "ls";
		subject.ReferenceIdentification = "t";
		subject.Date = "da0WALNc";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ls", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "w4";
		subject.ReferenceIdentification = "t";
		subject.Date = "da0WALNc";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "w4";
		subject.TransactionTypeCode = "ls";
		subject.Date = "da0WALNc";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("da0WALNc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "w4";
		subject.TransactionTypeCode = "ls";
		subject.ReferenceIdentification = "t";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
