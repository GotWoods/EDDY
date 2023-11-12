using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*tZ*K8*o*I2mNgh*bM1Z*UF";

		var expected = new BLS_BeginningSegmentForLeaseSchedule()
		{
			TransactionSetPurposeCode = "tZ",
			TransactionTypeCode = "K8",
			ReferenceNumber = "o",
			Date = "I2mNgh",
			Time = "bM1Z",
			AcknowledgmentType = "UF",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForLeaseSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForLeaseSchedule();
		//Required fields
		subject.TransactionTypeCode = "K8";
		subject.ReferenceNumber = "o";
		subject.Date = "I2mNgh";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K8", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForLeaseSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "tZ";
		subject.ReferenceNumber = "o";
		subject.Date = "I2mNgh";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForLeaseSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "tZ";
		subject.TransactionTypeCode = "K8";
		subject.Date = "I2mNgh";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I2mNgh", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForLeaseSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "tZ";
		subject.TransactionTypeCode = "K8";
		subject.ReferenceNumber = "o";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
