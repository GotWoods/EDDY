using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*hT*r6*6*KlvNahYp*1g76*5R";

		var expected = new BLS_BeginningSegmentForAssetSchedule()
		{
			TransactionSetPurposeCode = "hT",
			TransactionTypeCode = "r6",
			ReferenceIdentification = "6",
			Date = "KlvNahYp",
			Time = "1g76",
			AcknowledgmentTypeCode = "5R",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForAssetSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hT", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionTypeCode = "r6";
		subject.ReferenceIdentification = "6";
		subject.Date = "KlvNahYp";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r6", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "hT";
		subject.ReferenceIdentification = "6";
		subject.Date = "KlvNahYp";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "hT";
		subject.TransactionTypeCode = "r6";
		subject.Date = "KlvNahYp";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KlvNahYp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "hT";
		subject.TransactionTypeCode = "r6";
		subject.ReferenceIdentification = "6";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
