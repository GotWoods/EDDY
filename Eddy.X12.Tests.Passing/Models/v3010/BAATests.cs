using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAA*mu*2d*Mg9f8O*69*e*D0Dm";

		var expected = new BAA_BeginningSegmentForProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "mu",
			TransactionTypeCode = "2d",
			Date = "Mg9f8O",
			ReferenceNumberQualifier = "69",
			ReferenceNumber = "e",
			Time = "D0Dm",
		};

		var actual = Map.MapObject<BAA_BeginningSegmentForProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mu", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionTypeCode = "2d";
		subject.Date = "Mg9f8O";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2d", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "mu";
		subject.Date = "Mg9f8O";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mg9f8O", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAA_BeginningSegmentForProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "mu";
		subject.TransactionTypeCode = "2d";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
