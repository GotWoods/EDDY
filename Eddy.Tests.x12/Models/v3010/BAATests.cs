using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAA*ZG*sS*ocAvw6*XV*i*X5Yz";

		var expected = new BAA_BeginningSegmentForProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "ZG",
			TransactionTypeCode = "sS",
			Date = "ocAvw6",
			ReferenceNumberQualifier = "XV",
			ReferenceNumber = "i",
			Time = "X5Yz",
		};

		var actual = Map.MapObject<BAA_BeginningSegmentForProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZG", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionTypeCode = "sS";
		subject.Date = "ocAvw6";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sS", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "ZG";
		subject.Date = "ocAvw6";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ocAvw6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "ZG";
		subject.TransactionTypeCode = "sS";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
