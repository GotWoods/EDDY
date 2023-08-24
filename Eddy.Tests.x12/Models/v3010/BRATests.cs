using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*8*7SZFE0*Sz*x";

		var expected = new BRA_BeginningSegmentForReceivingAdvice()
		{
			ReferenceNumber = "8",
			Date = "7SZFE0",
			TransactionSetPurposeCode = "Sz",
			ReceivingAdviceTypeCode = "x",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.Date = "7SZFE0";
		subject.TransactionSetPurposeCode = "Sz";
		subject.ReceivingAdviceTypeCode = "x";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7SZFE0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "8";
		subject.TransactionSetPurposeCode = "Sz";
		subject.ReceivingAdviceTypeCode = "x";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sz", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "8";
		subject.Date = "7SZFE0";
		subject.ReceivingAdviceTypeCode = "x";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReceivingAdviceTypeCode(string receivingAdviceTypeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "8";
		subject.Date = "7SZFE0";
		subject.TransactionSetPurposeCode = "Sz";
		subject.ReceivingAdviceTypeCode = receivingAdviceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
