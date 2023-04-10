using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*7O*r8*I*IiJdNJC9*SHXw*DR";

		var expected = new BLS_BeginningSegmentForAssetSchedule()
		{
			TransactionSetPurposeCode = "7O",
			TransactionTypeCode = "r8",
			ReferenceIdentification = "I",
			Date = "IiJdNJC9",
			Time = "SHXw",
			AcknowledgmentTypeCode = "DR",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForAssetSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7O", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		subject.TransactionTypeCode = "r8";
		subject.ReferenceIdentification = "I";
		subject.Date = "IiJdNJC9";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r8", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		subject.TransactionSetPurposeCode = "7O";
		subject.ReferenceIdentification = "I";
		subject.Date = "IiJdNJC9";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		subject.TransactionSetPurposeCode = "7O";
		subject.TransactionTypeCode = "r8";
		subject.Date = "IiJdNJC9";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IiJdNJC9", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		subject.TransactionSetPurposeCode = "7O";
		subject.TransactionTypeCode = "r8";
		subject.ReferenceIdentification = "I";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
